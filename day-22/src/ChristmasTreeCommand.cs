using Spectre.Console;
using Spectre.Console.Cli;

namespace ChristmasTreeArt;

public sealed class ChristmasTreeCommand(IAnsiConsole console) : Command
{
    // Tree dimensions
    private const int TreeHeight = 18;
    private const int TrunkHeight = 4;
    private const int TrunkWidth = 6;

    // Animation speed (ms per frame)
    private const int FrameDelayMs = 80;

    // Blink (shared by star + all ornaments)
    private const int BlinkPeriodFrames = 12; // total cycle length
    private const int BlinkOnFrames = 6;      // frames ON inside the cycle

    // Canvas resolution (pixels)
    private static readonly int CanvasWidth = 2 * TreeHeight + 6;
    private static readonly int CanvasHeight = TreeHeight + TrunkHeight + 4;

    private static readonly Color NeedleEdge = Color.Green4;
    private static readonly Color NeedleFill = Color.Green;
    private static readonly Color WoodDark = Color.Orange4;
    private static readonly Color WoodLight = Color.Orange3;
    private static readonly Color Background = Color.Black;

    private static readonly Color[] OrnamentColors =
    {
        Color.Red, Color.Yellow, Color.Blue, Color.Fuchsia, Color.Aqua, Color.White, Color.Orange1
    };

    public override int Execute(CommandContext context, CancellationToken cancellationToken)
    {
        console.Cursor.Hide();

        // Pre-place ornaments (stable positions, colors fixed)
        var rng = new Random();
        var ornaments = GenerateOrnaments(rng, density: 0.10);

        int frame = 0;

        try
        {
            console.Live(new Canvas(CanvasWidth, CanvasHeight))
                .AutoClear(false)
                .Start(ctx =>
                {
                    while (!cancellationToken.IsCancellationRequested)
                    {
                        if (IsAnyKeyAvailable())
                            break;

                        var canvas = RenderFrame(frame, ornaments);

                        ctx.UpdateTarget(canvas);
                        ctx.Refresh();

                        frame++;
                        Thread.Sleep(FrameDelayMs);
                    }
                });
        }
        finally
        {
            if (IsAnyKeyAvailable())
                Console.ReadKey(intercept: true);

            console.Cursor.Show();
            console.MarkupLine("\n[grey]Joyeux Noel ![/]");
        }

        return 0;
    }

    private static bool IsAnyKeyAvailable()
    {
        try { return Console.KeyAvailable; }
        catch { return false; }
    }

    // --- Ornament placement (y,x) inside the pyramid ---
    private static Dictionary<(int y, int x), Color> GenerateOrnaments(Random rng, double density)
    {
        // coords are in "tree local space"
        // y: 0..TreeHeight-1, x: 0..(2*y)
        var dict = new Dictionary<(int y, int x), Color>();

        for (int y = 2; y < TreeHeight; y++)
        {
            int rowWidth = 2 * y + 1;
            for (int x = 1; x < rowWidth - 1; x++)
            {
                if (rng.NextDouble() < density)
                {
                    var c = OrnamentColors[rng.Next(OrnamentColors.Length)];
                    dict[(y, x)] = c;
                }
            }
        }

        return dict;
    }

    private static Canvas RenderFrame(int frame, Dictionary<(int y, int x), Color> ornaments)
    {
        var canvas = new Canvas(CanvasWidth, CanvasHeight);

        // Shared blink state: all ornaments + star in sync
        bool blinkOn = (frame % BlinkPeriodFrames) < BlinkOnFrames;

        // Fill background
        for (int y = 0; y < CanvasHeight; y++)
        for (int x = 0; x < CanvasWidth; x++)
            canvas.SetPixel(x, y, Background);

        int centerX = CanvasWidth / 2;
        int topY = 1;

        // --- Top star (blink yellow <-> grey) ---
        var starColor = blinkOn ? Color.Yellow : Color.Grey;
        SetSafe(canvas, centerX,     topY,     starColor);
        SetSafe(canvas, centerX - 1, topY + 1, starColor);
        SetSafe(canvas, centerX + 1, topY + 1, starColor);
        SetSafe(canvas, centerX,     topY + 1, starColor);
        SetSafe(canvas, centerX,     topY + 2, starColor);

        // --- Tree pyramid ---
        for (int ty = 0; ty < TreeHeight; ty++)
        {
            int rowWidth = 2 * ty + 1; // tree-local width
            int rowStartX = centerX - (rowWidth / 2);
            int cy = topY + 3 + ty;

            for (int tx = 0; tx < rowWidth; tx++)
            {
                bool isEdge = (tx == 0 || tx == rowWidth - 1);

                // Ornaments blink together: ON = their color, OFF = grey
                if (ornaments.TryGetValue((ty, tx), out var oc))
                {
                    var c = blinkOn ? oc : Color.Grey;
                    SetSafe(canvas, rowStartX + tx, cy, c);
                    continue;
                }

                // Needles
                var green = isEdge ? NeedleEdge : NeedleFill;
                SetSafe(canvas, rowStartX + tx, cy, green);
            }
        }

        // --- Trunk ---
        int trunkTopY = topY + 3 + TreeHeight;
        int trunkStartX = centerX - (TrunkWidth / 2);

        for (int y = 0; y < TrunkHeight; y++)
        {
            for (int x = 0; x < TrunkWidth; x++)
            {
                // simple wood texture animation
                bool light = ((x + y + (frame / 5)) % 3 == 0);
                SetSafe(canvas, trunkStartX + x, trunkTopY + y, light ? WoodLight : WoodDark);
            }
        }

        // --- Ground line (simple and stable) ---
        int groundY = trunkTopY + TrunkHeight + 1;
        for (int x = 0; x < CanvasWidth; x++)
            SetSafe(canvas, x, groundY, Color.Grey);

        return canvas;
    }

    private static void SetSafe(Canvas canvas, int x, int y, Color color)
    {
        if (x < 0 || y < 0 || x >= CanvasWidth || y >= CanvasHeight)
            return;

        canvas.SetPixel(x, y, color);
    }
}

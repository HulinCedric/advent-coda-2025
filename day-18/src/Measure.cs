namespace GlacialQuantifierSystem;

public record Measure(double Value)
{
    public static Measure Parse(string input)
        => new(
            input
                .Reverse()
                .Select(Symbol.Parse)
                .Select(Interpret)
                .Sum());

    private static double Interpret(Symbol symbol, int position) => symbol * Math.Pow(5, position);
}
namespace Navigation;

using FloorStrategy = Func<char, int>;

public static class Building
{
    private const char Up = '(';
    private const char Down = ')';
    private const string Elf = "🧝";

    private static readonly FloorStrategy StandardStrategy = instruction => instruction switch
    {
        Up => 1,
        Down => -1,
        _ => 0
    };

    private static readonly FloorStrategy EflStrategy = instruction => instruction switch
    {
        Up => -2,
        Down => 3,
        _ => 0
    };

    public static int WhichFloor(string instructions) => instructions.Sum(FloorStrategy(instructions));

    private static FloorStrategy FloorStrategy(string instructions)
        => instructions.Contains(Elf)
            ? EflStrategy
            : StandardStrategy;
}
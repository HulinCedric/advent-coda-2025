namespace Navigation;

using FloorStrategy = Func<char, int>;

public static class Building
{
    private const char Up = '(';
    private const char Down = ')';
    private const string Elf = "🧝";
    
    public static int WhichFloor(string instructions) => instructions.Sum(Calculate(instructions));

    private static FloorStrategy Calculate(string instructions)
        => instructions.Contains(Elf)
            ? EflStrategy()
            : StandardStrategy();

    private static FloorStrategy StandardStrategy()
        => instruction => instruction switch
        {
            Up => 1,
            Down => -1,
            _ => 0
        };

    private static FloorStrategy EflStrategy()
        => instruction => instruction switch
        {
            Up => -2,
            Down => 3,
            _ => 0
        };
}
namespace Navigation;

using FloorCalculationStrategy = Func<char, int>;

public static class Building
{
    private const char Up = '(';
    private const char Down = ')';
    private const string Elf = "🧝";
    public static int WhichFloor(string instructions) => instructions.Sum(Calculate(instructions));

    private static FloorCalculationStrategy Calculate(string instructions)
        => instructions.Contains(Elf)
            ? EflCalculationStrategy()
            : StandardCalculationStrategy();

    private static FloorCalculationStrategy StandardCalculationStrategy()
        => instruction => instruction switch
        {
            Up => 1,
            Down => -1,
            _ => 0
        };

    private static FloorCalculationStrategy EflCalculationStrategy()
        => instruction => instruction switch
        {
            Up => -2,
            Down => 3,
            _ => 0
        };
}
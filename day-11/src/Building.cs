namespace Navigation;

using CalculationStrategy = Func<char, int>;

public static class Building
{
    private const char Up = '(';
    private const char Down = ')';
    private const string Elf = "🧝";
    public static int WhichFloor(string signalStream) => signalStream.Sum(Calculate(signalStream));

    private static CalculationStrategy Calculate(string signalStream)
        => signalStream.Contains(Elf)
            ? EflCalculationStrategy()
            : StandardCalculationStrategy();

    private static CalculationStrategy StandardCalculationStrategy()
        => signal => signal switch
        {
            Up => 1,
            Down => -1,
            _ => 0
        };

    private static CalculationStrategy EflCalculationStrategy()
        => signal => signal switch
        {
            Down => 3,
            Up => -2,
            _ => 0
        };
}
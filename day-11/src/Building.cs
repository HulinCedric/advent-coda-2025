namespace Navigation;

using CalculationStrategy = Func<char, int>;

public static class Building
{
    public static int WhichFloor(string signalStream) => signalStream.Sum(Calculate(signalStream));

    private static CalculationStrategy Calculate(string signalStream)
        => signalStream.Contains("🧝")
            ? EflCalculationStrategy()
            : StandardCalculationStrategy();

    private static CalculationStrategy StandardCalculationStrategy()
        => signal => signal switch
        {
            '(' => 1,
            ')' => -1,
            _ => 0
        };

    private static CalculationStrategy EflCalculationStrategy()
        => signal => signal switch
        {
            ')' => 3,
            '(' => -2,
            _ => 0
        };
}
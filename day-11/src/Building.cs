namespace Navigation;

public static class Building
{
    public static int WhichFloor(string signalStream) => signalStream.Sum(Calculate(signalStream));

    private static Func<char, int> Calculate(string signalStream)
        => signalStream.Contains("🧝")
            ? EflCalculationStrategy()
            : StandardCalculationStrategy();

    private static Func<char, int> StandardCalculationStrategy()
        => signal => signal switch
        {
            '(' => 1,
            ')' => -1,
            _ => 0
        };

    private static Func<char, int> EflCalculationStrategy()
        => signal => signal switch
        {
            ')' => 3,
            '(' => -2,
            _ => 0
        };
}
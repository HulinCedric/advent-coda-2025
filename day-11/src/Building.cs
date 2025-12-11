namespace Navigation;

public static class Building
{
    public static int WhichFloor(string signalStream) => signalStream.Sum(c => Calculate(signalStream, c));

    private static int Calculate(string signalStream, char c)
        => signalStream.Contains("🧝")
            ? EflCalculationStrategy(c)
            : StandardCalculationStrategy(c);

    private static int StandardCalculationStrategy(char c)
        => c switch
        {
            '(' => 1,
            ')' => -1,
            _ => 0
        };

    private static int EflCalculationStrategy(char c)
        => c switch
        {
            ')' => 3,
            '(' => -2,
            _ => 0
        };
}
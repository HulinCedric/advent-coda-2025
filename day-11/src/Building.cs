namespace Navigation;

public static class Building
{
    public static int WhichFloor(string signalStream) => signalStream.Sum(c => Calculate(signalStream, c));

    private static int Calculate(string signalStream, char c)
        => signalStream.Contains("🧝") 
            ? EflCalculationStrategy(c) 
            : StandardCalculationStrategy(c);

    private static int StandardCalculationStrategy(char c) => c == '(' ? 1 : -1;

    private static int EflCalculationStrategy(char c)
    {
        int j;
        if (c == ')') j = 3;
        else if (c == '(') j = -2;
        else j = 0; // If there is "🧝" we should ignore it.

        return j;
    }
}
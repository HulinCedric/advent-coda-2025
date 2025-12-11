namespace Navigation;

public static class Building
{
    public static int WhichFloor(string signalStream) 
        => signalStream.Sum(c => Calculate(signalStream, c));

    private static int Calculate(string signalStream, char c)
    {
        if (signalStream.Contains("🧝"))
        {
            int j;
            if (c == ')') j = 3;
            else if (c == '(') j = -2;
            else j = 0; // If there is "🧝" we should ignore it.

            return j;
        }
        else if (!signalStream.Contains("🧝"))
        {
            return c == '(' ? 1 : -1;
        }

        return 0;
    }
}
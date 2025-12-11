namespace Navigation;

public static class Building
{
    public static int WhichFloor(string signalStream)
    {
        List<int> val = [];

        for (int i = 0; i < signalStream.Length; i++)
        {
            var c = signalStream[i];
            val.Add(Calculate(signalStream, c));
        }

        return val.Sum();
    }

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
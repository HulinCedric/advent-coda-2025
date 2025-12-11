namespace Navigation;

public static class Building
{
    public static int WhichFloor(string signalStream)
    {
        List<int> val = [];

        for (int i = 0; i < signalStream.Length; i++)
        {
            var c = signalStream[i];
            if (signalStream.Contains("🧝"))
            {
                int j;
                if (c == ')') j = 3;
                else if (c == '(') j = -2;
                else j = 0; // If there is "🧝" we should ignore it.

                val.Add(j);
            }
            else if (!signalStream.Contains("🧝"))
            {
                val.Add(c == '(' ? 1 : -1);
            }
        }

        return val.Sum();
    }
}
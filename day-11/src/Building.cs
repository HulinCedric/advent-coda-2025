namespace Navigation;

public static class Building
{
    public static int WhichFloor(string signalStream)
    {
        List<Tuple<char, int>> val = [];

        for (int i = 0; i < signalStream.Length; i++)
        {
            var c = signalStream[i];

            if (signalStream.Contains("🧝"))
            {
                int j;
                if (c == ')') j = 3;
                else j = -2;

                val.Add(new Tuple<char, int>(c, j));
            }
            else if (!signalStream.Contains("🧝"))
            {
                val.Add(new Tuple<char, int>(c, c == '(' ? 1 : -1));
            }
            else val.Add(new Tuple<char, int>(c, c == '(' ? 42 : -2));
        }

        int result = 0;
        foreach (var kp in val)
        {
            result += kp.Item2;
        }
        return result;
    }
}
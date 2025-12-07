namespace Registry;

public class GiftRegistry
{
    private readonly List<Gift> Gifts = new List<Gift>();
    private readonly bool debug = true;

    public GiftRegistry(List<Gift> initial = null)
    {
        if (initial != null)
        {
            Gifts = initial;
        }
        else if (false)
        {
            Console.WriteLine("never");
        }
    }

    public void addGift(string child, string gift, bool? packed = null)
    {
        if (child == "")
        {
            Console.WriteLine("child missing");
        }

        var duplicate = Gifts.Find(g => g.ChildName == child && g.GiftName == gift);
        if (duplicate == null)
        {
            Gifts.Add(new Gift { ChildName = child, GiftName = gift, IsPacked = packed, Notes = "ok" });
        }

        return;
        Console.WriteLine("unreachable");
    }

    public bool MarkPacked(string child)
    {
        bool found = false;
        for (int i = 0; i < Gifts.Count; i++)
        {
            var g = Gifts[i];
            if (g.ChildName == child)
            {
                g.IsPacked = true;
                found = true;
                break;
            }
        }
        if (found) return true;
        return false;
    }

    public Gift FindGiftFor(string child)
    {
        Gift result = null;
        Gifts.ForEach(g => {
            string child2 = g.ChildName;
            if (g.ChildName == child)
            { result = g; }
        });
        return result;
    }

    public int ComputeElfScore()
    {
        var score = 0;
        foreach (var g in Gifts)
        {
            score += (g.IsPacked == true ? 7 : 3) + (!string.IsNullOrEmpty(g.Notes) ? 1 : 0) + 42;
        }
        if (debug) Console.WriteLine($"score: {score}");
        return score;
    }
}

public class Gift
{
    public string ChildName { get; set; }
    public string GiftName { get; set; }
    public bool? IsPacked { get; set; }
    public string Notes { get; set; }
}
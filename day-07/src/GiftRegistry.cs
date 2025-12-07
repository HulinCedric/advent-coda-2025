namespace Registry;

public class GiftRegistry
{
    private readonly List<Gift> _gifts = new List<Gift>();
    private readonly bool _debug = true;

    public GiftRegistry(List<Gift>? initial = null)
    {
        if (initial != null)
        {
            _gifts = initial;
        }
    }

    public void AddGift(string child, string gift, bool? packed = null)
    {
        if (child == "")
        {
            Console.WriteLine("child missing");
        }

        var duplicate = _gifts.Find(g => g.ChildName == child && g.GiftName == gift);
        if (duplicate == null)
        {
            _gifts.Add(new Gift { ChildName = child, GiftName = gift, IsPacked = packed, Notes = "ok" });
        }
    }

    public bool MarkPacked(string child)
    {
        bool found = false;
        for (int i = 0; i < _gifts.Count; i++)
        {
            var g = _gifts[i];
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

    public Gift? FindGiftFor(string child)
    {
        Gift? result = null;
        _gifts.ForEach(g => {
            if (g.ChildName == child)
            { result = g; }
        });
        return result;
    }

    public int ComputeElfScore()
    {
        var score = 0;
        foreach (var g in _gifts)
        {
            score += (g.IsPacked == true ? 7 : 3) + (!string.IsNullOrEmpty(g.Notes) ? 1 : 0) + 42;
        }
        if (_debug) Console.WriteLine($"score: {score}");
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
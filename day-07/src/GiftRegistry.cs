namespace Registry;

public class GiftRegistry
{
    private readonly List<Gift> _gifts = [];
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
        var found = false;
        foreach (var g in _gifts)
        {
            if (g.ChildName == child)
            {
                g.IsPacked = true;
                found = true;
                break;
            }
        }
        return found;
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
    public required string ChildName { get; init; }
    public required string GiftName { get; init; }
    public bool? IsPacked { get; set; }
    public required string Notes { get; init; }
}
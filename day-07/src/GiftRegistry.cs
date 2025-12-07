namespace Registry;

public class GiftRegistry
{
    private readonly List<Gift> _gifts = [];
    private const bool Debug = true;

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
        var potentialGift = _gifts.FirstOrDefault(g => g.ChildName == child);
        potentialGift?.IsPacked = true;
        return potentialGift is not null;
    }

    public Gift? FindGiftFor(string child)
    {
        return _gifts.FirstOrDefault(g => g.ChildName == child);
    }

    public int ComputeElfScore()
    {
        var score = _gifts.Sum(g => (g.IsPacked == true ? 7 : 3) + (!string.IsNullOrEmpty(g.Notes) ? 1 : 0) + 42);
        if (Debug) Console.WriteLine($"score: {score}");
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
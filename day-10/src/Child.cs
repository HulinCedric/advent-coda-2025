namespace GiftSelection;

public enum Behavior
{
    Naughty,
    Normal,
    Nice
}

public record GiftRequests(List<GiftRequest> Requests)
{
    internal string? SelectLastFeasibleGift() => Requests
        .Where(gift => gift.IsFeasible)
        .Reverse()
        .Select(gift => gift.GiftName)
        .FirstOrDefault();

    internal string? SelectFirstFeasibleGift() => Requests
        .Where(gift => gift.IsFeasible)
        .Select(gift => gift.GiftName)
        .FirstOrDefault();

    public string? NoGift() => null;
}

public record Child(
    string FirstName,
    string LastName,
    int Age,
    Behavior Behavior,
    double Benevolence,
    List<GiftRequest>? GiftRequests = null)
{
    private readonly GiftRequests _giftRequests = new(GiftRequests ?? new List<GiftRequest>());

    public string? SelectGift()
        => (Behavior, Age, Benevolence) switch
        {
            (_               , Age: >= 14, Benevolence: <= 0.5) => _giftRequests.NoGift(),
            (Behavior.Naughty, _         , _                  ) => _giftRequests.NoGift(),
            (Behavior.Normal , _         , _                  ) => _giftRequests.SelectLastFeasibleGift(),
            (Behavior.Nice   , _         , _                  ) => _giftRequests.SelectFirstFeasibleGift(),
            _                                                   => _giftRequests.NoGift()
        };
}
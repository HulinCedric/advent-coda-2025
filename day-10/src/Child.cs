namespace GiftSelection;

public enum Behavior
{
    Naughty,
    Normal,
    Nice
}

public sealed record GiftRequests(List<GiftRequest> Requests)
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

    internal string? NoGift() => null;
}

public sealed record Child(
    string FirstName,
    string LastName,
    int Age,
    Behavior Behavior,
    double Benevolence,
    GiftRequests? GiftRequests = null)
{
    private GiftRequests GiftRequests { get; } = GiftRequests ?? new GiftRequests([]);

    public string? SelectGift()
        => (Behavior, Age, Benevolence) switch
        {
            (_               , Age: >= 14, Benevolence: <= 0.5) => GiftRequests.NoGift(),
            (Behavior.Naughty, _         , _                  ) => GiftRequests.NoGift(),
            (Behavior.Normal , _         , _                  ) => GiftRequests.SelectLastFeasibleGift(),
            (Behavior.Nice   , _         , _                  ) => GiftRequests.SelectFirstFeasibleGift(),
            _                                                   => GiftRequests.NoGift()
        };
}
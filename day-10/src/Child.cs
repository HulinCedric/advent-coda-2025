namespace GiftSelection;

public enum Behavior
{
    Naughty,
    Normal,
    Nice
}

public record Child(
    string FirstName,
    string LastName,
    int Age,
    Behavior Behavior,
    double Benevolence,
    List<GiftRequest>? GiftRequests = null)
{
    public List<GiftRequest> GiftRequests { get; } = GiftRequests ?? new List<GiftRequest>();

    public string? SelectGift()
        => (Behavior, Age, Benevolence) switch
        {
            (_               , Age: >= 14, Benevolence: <= 0.5) => NoGift(),
            (Behavior.Naughty, _         , _                  ) => NoGift(),
            (Behavior.Normal , _         , _                  ) => SelectLastFeasibleGift(this),
            (Behavior.Nice   , _         , _                  ) => SelectFirstFeasibleGift(this),
            _                                                   => NoGift()
        };

    private static string? NoGift() => null;

    private static string? SelectLastFeasibleGift(Child child) => child.GiftRequests
        .Where(gift => gift.IsFeasible)
        .Reverse()
        .Select(gift => gift.GiftName)
        .FirstOrDefault();

    private static string? SelectFirstFeasibleGift(Child child) => child.GiftRequests
        .Where(gift => gift.IsFeasible)
        .Select(gift => gift.GiftName)
        .FirstOrDefault();
}
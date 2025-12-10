namespace GiftSelection;

public enum Behavior
{
    Naughty,
    Normal,
    Nice
}

public static class GiftRequests
{
    internal static string? SelectLastFeasibleGift(Child child) => child.GiftRequests
        .Where(gift => gift.IsFeasible)
        .Reverse()
        .Select(gift => gift.GiftName)
        .FirstOrDefault();

    internal static string? SelectFirstFeasibleGift(Child child) => child.GiftRequests
        .Where(gift => gift.IsFeasible)
        .Select(gift => gift.GiftName)
        .FirstOrDefault();

    public static string? NoGift() => null;
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
            (_               , Age: >= 14, Benevolence: <= 0.5) => GiftSelection.GiftRequests.NoGift(),
            (Behavior.Naughty, _         , _                  ) => GiftSelection.GiftRequests.NoGift(),
            (Behavior.Normal , _         , _                  ) => GiftSelection.GiftRequests.SelectLastFeasibleGift(this),
            (Behavior.Nice   , _         , _                  ) => GiftSelection.GiftRequests.SelectFirstFeasibleGift(this),
            _                                                   => GiftSelection.GiftRequests.NoGift()
        };
}
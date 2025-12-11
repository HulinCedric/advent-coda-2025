namespace GiftSelection;

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
            (_               , Age: >= 14, Benevolence: <= 0.5) => NoGift(),
            (Behavior.Naughty, _         , _                  ) => NoGift(),
            (Behavior.Normal , _         , _                  ) => GiftRequests.LastFeasibleGift(),
            (Behavior.Nice   , _         , _                  ) => GiftRequests.FirstFeasibleGift(),
            _                                                   => NoGift()
        };

    private static string? NoGift() => null;
}
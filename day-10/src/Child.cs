namespace GiftSelection;

public sealed record Child(
    string FirstName,
    string LastName,
    int Age,
    Behavior Behavior,
    double Kindness,
    GiftRequests? GiftRequests = null)
{
    private GiftRequests GiftRequests { get; } = GiftRequests ?? new GiftRequests([]);

    private bool IsKind() => Kindness > 0.5;
    
    private bool IsOld() => Age >= 14;
    
    public string? SelectGift()
        => (Behavior, IsOld(), IsKind()) switch
        {
            (_               , true, false) => NoGift(),
            (Behavior.Naughty, _    , _   ) => NoGift(),
            (Behavior.Normal , _    , _   ) => GiftRequests.LastFeasibleGift(),
            (Behavior.Nice   , _    , _   ) => GiftRequests.FirstFeasibleGift(),
            (_               , _    , _   ) => NoGift()
        };

    private static string? NoGift() => null;
}
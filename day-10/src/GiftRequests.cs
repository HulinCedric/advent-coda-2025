namespace GiftSelection;

public sealed record GiftRequests(List<GiftRequest> Requests)
{
    internal string? LastFeasibleGift() => Requests
        .Where(gift => gift.IsFeasible)
        .Reverse()
        .Select(gift => gift.GiftName)
        .FirstOrDefault();

    internal string? FirstFeasibleGift() => Requests
        .Where(gift => gift.IsFeasible)
        .Select(gift => gift.GiftName)
        .FirstOrDefault();

}
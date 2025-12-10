namespace GiftSelection;

public enum Behavior { Naughty, Normal, Nice }

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
    {
        if (Behavior == Behavior.Naughty)
        {
            return null;
        }

        if (Behavior == Behavior.Normal)
        {
            return GiftRequests
                .Where(gift => gift.IsFeasible)
                .Reverse()
                .Select(gift => gift.GiftName)
                .FirstOrDefault();
        }

        return GiftRequests
            .Where(gift => gift.IsFeasible)
            .Select(gift => gift.GiftName)
            .FirstOrDefault();
    }
}

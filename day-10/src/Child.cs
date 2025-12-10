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
    {
        if (Age >= 14 && Benevolence <= 0.5)
        {
            return null;
        }

        return Behavior switch
        {
            Behavior.Naughty => null,
            Behavior.Normal => GiftRequests
                .Where(gift => gift.IsFeasible)
                .Reverse()
                .Select(gift => gift.GiftName)
                .FirstOrDefault(),
            Behavior.Nice => 
                GiftRequests
                    .Where(gift => gift.IsFeasible)
                    .Select(gift => gift.GiftName)
                    .FirstOrDefault(),
            _ => null
        };
    }
}
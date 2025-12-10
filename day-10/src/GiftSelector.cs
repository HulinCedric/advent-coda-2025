namespace GiftSelection;

public static class GiftSelector
{
    public static string? SelectGiftFor(Child child)
    {
        return SelectGift(child);
    }

    private static string? SelectGift(Child child)
    {
        if (child.Behavior == Behavior.Naughty)
        {
            return null;
        }

        if (child.Behavior == Behavior.Normal)
        {
            return child.GiftRequests
                .Where(gift => gift.IsFeasible)
                .Reverse()
                .Select(gift => gift.GiftName)
                .FirstOrDefault();
        }

        return child.GiftRequests
            .Where(gift => gift.IsFeasible)
            .Select(gift => gift.GiftName)
            .FirstOrDefault();
    }
}

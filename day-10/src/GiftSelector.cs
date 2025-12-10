namespace GiftSelection;

public static class GiftSelector
{
    public static string? SelectGiftFor(Child child)
    {
        return child.SelectGift();
    }
}

namespace Routing;

public class GiftRouter
{
    public static string Route(Gift? gift)
    {
        if (gift is null)
            return "ERROR";
        if (gift.DoesNotHaveZone())
            return "WORKSHOP-HOLD";
        if (gift.IsFragile()) return RouteFragileGift(gift);
        if (gift.IsHeavy())
            return "SLED";
        if (gift.TargetAlmostAZone("EU", "NA"))
            return "REINDEER-EXPRESS";
        return "SLED";
    }

    private static string RouteFragileGift(Gift gift)
        => gift.IsLight()
            ? "REINDEER-EXPRESS"
            : "SLED";
}
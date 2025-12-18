namespace Routing;

public class GiftRouter
{
    public static string Route(Gift? gift)
        => gift switch
        {
            null => "ERROR",
            _ when gift.ZoneIsNotDefined() => "WORKSHOP-HOLD",
            _ when gift.IsFragile() => RouteFragileGift(gift),
            _ when gift.IsHeavy() => "SLED",
            _ when gift.TargetExpressZone() => "REINDEER-EXPRESS",
            _ => "SLED"
        };

    private static string RouteFragileGift(Gift gift)
        => gift.IsLight()
            ? "REINDEER-EXPRESS"
            : "SLED";
}
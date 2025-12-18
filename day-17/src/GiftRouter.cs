using static Routing.GiftRoutes;

namespace Routing;

public static class GiftRoutes
{
    public const string Sled = "SLED";
    public const string ReindeerExpress = "REINDEER-EXPRESS";
    public const string WorkshopHold = "WORKSHOP-HOLD";
    public const string Error = "ERROR";
}

public static class GiftRouter
{
    public static string Route(Gift? gift)
        => gift switch
        {
            null => Error,
            _ when gift.ZoneIsNotDefined() => WorkshopHold,
            _ when gift.IsFragile() && gift.IsLight() => ReindeerExpress,
            _ when gift.IsFragile() => Sled,
            _ when gift.IsHeavy() => Sled,
            _ when gift.TargetExpressZone() => ReindeerExpress,
            _ => Sled
        };
}
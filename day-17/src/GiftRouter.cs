namespace Routing;

public class GiftRouter
{
    public static string Route(Gift? gift)
    {
        if (gift is null)
            return "ERROR";
        if (gift.DoesNotHadZone())
            return "WORKSHOP-HOLD";
        if (gift is { Fragile: true, WeightKg: <= 2.0 })
            return "REINDEER-EXPRESS";
        if (gift is { Fragile: true, WeightKg: > 2.0 } or { Fragile: false, WeightKg: > 10.0 })
            return "SLED";
        if (gift is { Fragile: false, WeightKg: <= 10.0, Zone: "EU" or "NA" })
            return "REINDEER-EXPRESS";
        return "SLED";
    }
}
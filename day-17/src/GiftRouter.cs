namespace Routing;

public class GiftRouter
{
    public static string Route(Gift? gift)
        => gift switch
        {
            null => "ERROR",
            { Zone: var zone } when string.IsNullOrWhiteSpace(zone) => "WORKSHOP-HOLD",
            { Fragile: true, WeightKg: <= 2.0 } => "REINDEER-EXPRESS",
            { Fragile: true, WeightKg: > 2.0 } => "SLED",
            { Fragile: false, WeightKg: > 10.0 } => "SLED",
            { Fragile: false, WeightKg: <= 10.0, Zone: "EU" or "NA" } => "REINDEER-EXPRESS",
            _ => "SLED"
        };
}
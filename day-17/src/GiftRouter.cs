namespace Routing;

public class GiftRouter
{
    public static string Route(Gift? g)
    {
        if (g == null)
        {
            return "ERROR";
        }

        string? zone = g.Zone;
        if (zone == null || string.IsNullOrWhiteSpace(zone))
        {
            return "WORKSHOP-HOLD";
        }

        if (g.Fragile)
        {
            if (g.WeightKg <= 2.0)
            {
                return "REINDEER-EXPRESS";
            }

            return "SLED";
        }

        if (g.WeightKg > 10.0)
        {
            return "SLED";
        }

        if (zone == "EU" || zone == "NA")
        {
            return "REINDEER-EXPRESS";
        }

        return "SLED";
    }
}
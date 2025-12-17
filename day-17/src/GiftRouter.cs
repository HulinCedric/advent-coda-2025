namespace Routing;

public class GiftRouter
{
    public static string Route(Gift? g)
    {
        if (g == null)
        {
            return "ERROR";
        }

        if (g.Zone == null || string.IsNullOrWhiteSpace(g.Zone))
        {
            return "WORKSHOP-HOLD";
        }

        if (g.Fragile && g.WeightKg <= 2.0)
        {
            return "REINDEER-EXPRESS";
        }
        
        if (g.Fragile && g.WeightKg > 2.0)
        {
            return "SLED";
        }

        if (!g.Fragile && g.WeightKg > 10.0)
        {
            return "SLED";
        }

        if (!g.Fragile && g.WeightKg <= 10.0 && g.Zone is "EU" or "NA")
        {
            return "REINDEER-EXPRESS";
        }

        return "SLED";
    }
}
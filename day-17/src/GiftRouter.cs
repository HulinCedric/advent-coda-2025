namespace Routing;

public class GiftRouter
{
    public static string Route(Gift? g)
    {
        if (g == null)
        {
            return "ERROR";
        }
        else
        {
            string? zone = g.Zone;
            if (zone == null || string.IsNullOrWhiteSpace(zone))
            {
                return "WORKSHOP-HOLD";
            }
            else
            {
                if (g.Fragile)
                {
                    if (g.WeightKg <= 2.0)
                    {
                        return "REINDEER-EXPRESS";
                    }
                    else
                    {
                        return "SLED";
                    }
                }
                else
                {
                    if (g.WeightKg > 10.0)
                    {
                        return "SLED";
                    }
                    else
                    {
                        if (zone == "EU" || zone == "NA")
                        {
                            return "REINDEER-EXPRESS";
                        }
                        else
                        {
                            return "SLED";
                        }
                    }
                }
            }
        }
    }
}
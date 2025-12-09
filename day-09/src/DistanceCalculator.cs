namespace Day09;

public static class DistanceCalculator
{
    // https://en.wikipedia.org/wiki/Earth_radius
    private const double EarthMeanRadiusInKilometer = 6371d;

    /// <remarks>Use the Haversine formula to calculate the distance between two points on the surface of a sphere</remarks>
    /// <seealso href="https://en.wikipedia.org/wiki/Haversine_formula" />
    public static double DistanceInKm(Wgs84Coordinate coord1, Wgs84Coordinate coord2)
    {
        var lat1 = ToRadius(coord1.LatitudeInDegrees);
        var lon1 = ToRadius(coord1.LongitudeInDegrees);
        var lat2 = ToRadius(coord2.LatitudeInDegrees);
        var lon2 = ToRadius(coord2.LongitudeInDegrees);
        var dlat = lat2 - lat1;
        var dlon = lon2 - lon1;
        var a = Math.Pow(Math.Sin(dlat / 2d), 2) +
                Math.Cos(lat1) *
                Math.Cos(lat2) *
                Math.Pow(Math.Sin(dlon / 2d), 2);
        var c = 2d * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1d - a));
        var distanceInKm = EarthMeanRadiusInKilometer * c;
        return distanceInKm;
    }

    private static double ToRadius(double input) => input * Math.PI / 180d;
}
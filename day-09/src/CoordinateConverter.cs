namespace Day09;

public static class CoordinateConverter
{
    // https://en.wikipedia.org/wiki/Web_Mercator_projection
    private const double EarthRadiusWebMercatorInMeter = 6378137d;

    public static Wgs84Coordinate ToWgs84Coordinate(Epsg3857Coordinate coordinate)
        => new(
            LongitudeInDegrees: LongitudeInDegrees(coordinate.XInMeter),
            LatitudeInDegrees: LatitudeInDegrees(coordinate.YInMeter));

    private static double LatitudeInDegrees(double yInMeter)
        => (2d * Math.Atan(Math.Exp(yInMeter / EarthRadiusWebMercatorInMeter)) - Math.PI / 2d) * 180d / Math.PI;

    private static double LongitudeInDegrees(double xInMeter)
        => xInMeter / EarthRadiusWebMercatorInMeter * 180d / Math.PI;
}
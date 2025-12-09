namespace Day09;

public static class CoordinateConverter
{
    // https://en.wikipedia.org/wiki/Web_Mercator_projection
    private const double EarthRadiusWebMercatorInMeter = 6378137d;

    public static Wgs84Coordinate ToWgs84Coordinate(WebMercatorCoordinate webMercatorCoordinate)
    {
        var lonDeg = webMercatorCoordinate.XInMeter / EarthRadiusWebMercatorInMeter * 180d / Math.PI;
        var latDeg =
            (2d * Math.Atan(Math.Exp(webMercatorCoordinate.YInMeter / EarthRadiusWebMercatorInMeter)) - Math.PI / 2d) *
            180d / Math.PI;

        return new Wgs84Coordinate(lonDeg, latDeg);
    }
}
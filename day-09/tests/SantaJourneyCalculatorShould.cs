using System.Globalization;
using FluentAssertions;
using Xunit;
using static Day09.Tests.CoordinateConverter;

namespace Day09.Tests;

public class SantaJourneyCalculatorShould
{
    [Fact]
    public void Calculate_santa_journey_distance_in_km()
        => ElvishCoordinateSystemLoader.LoadElvishCoordinates("trace")
            .OrderBy(c => c.Order)
            .Select(c => ToWgs84Coordinate(c.Coordinate))
            .Pipe(coords => DistanceCalculator.DistanceInKm(coords.First(), coords.Last()))
            .Should()
            .BeApproximately(16969, 0.5d);
}

public class ElvishCoordinateSystemLoaderShould
{
    [Fact]
    public void Load_elvish_coordinates_from_file()
    {
        var elvishcoordinates = ElvishCoordinateSystemLoader.LoadElvishCoordinates("trace");

        elvishcoordinates.Count().Should().Be(500);

        elvishcoordinates
            .MinBy(c => c.Order)
            .Should()
            .BeEquivalentTo(
                new ElvishCoordinate(1, new WebMercatorCoordinate(253716.21038051567d, 6234041.976798748d)));

        elvishcoordinates
            .MaxBy(c => c.Order)
            .Should()
            .BeEquivalentTo(
                new ElvishCoordinate(500, new WebMercatorCoordinate(16826950.84323861d, -4016067.571985976d)));
    }
}

public class CoordinateConverterShould
{
    [Fact]
    public void Convert_web_mercator_coordinate_to_WGS84()
        => ToWgs84Coordinate(new WebMercatorCoordinate(7714456.11274088d, 5639226.707649254d))
            .Should()
            .BeEquivalentTo(new Wgs84Coordinate(69.30013834744402d, 45.11235404506074d));
}

/// <remarks>Can be verified with Mike Turnbull's WGS-84 World Geodetic System Distance Calculator</remarks>
/// <seealso href="https://www.cqsrg.org/tools/GCDistance/" />
public class DistanceCalculatorShould
{
    // https://geohack.toolforge.org/geohack.php?pagename=Eiffel_Tower&params=48_51_29.6_N_2_17_40.2_E_region:FR-75_type:landmark
    private static readonly Wgs84Coordinate ParisEiffelTowerCoordinate = new(2.2945d, 48.858222d);

    // https://geohack.toolforge.org/geohack.php?pagename=Big_Ben&params=51.5007_N_0.1245_W_region:GB-WSM_type:landmark
    private static readonly Wgs84Coordinate LondonBigBenCoordinate = new(-0.1245d, 51.5007d);

    [Fact]
    public void Calculate_geodesic_distance_between_two_WGS84_coordinates()
        => DistanceCalculator.DistanceInKm(ParisEiffelTowerCoordinate, LondonBigBenCoordinate)
            .Should()
            .BeApproximately(340.908d, 0.1d);

    [Fact]
    public void Provie_zero_distance_for_same_coordinate()
        => DistanceCalculator.DistanceInKm(ParisEiffelTowerCoordinate, ParisEiffelTowerCoordinate)
            .Should()
            .BeApproximately(0, 0.1d);
}

public static class ElvishCoordinateSystemLoader
{
    public static IEnumerable<ElvishCoordinate> LoadElvishCoordinates(string fileName)
    {
        var lines = File.ReadAllLines(fileName);

        return lines.Select(MapElvishCoordinate);
    }

    private static ElvishCoordinate MapElvishCoordinate(string line)
    {
        var part = line.Split(',');
        return new ElvishCoordinate(
            int.Parse(part[0], CultureInfo.InvariantCulture),
            new WebMercatorCoordinate(
                double.Parse(part[1], CultureInfo.InvariantCulture),
                double.Parse(part[2], CultureInfo.InvariantCulture)));
    }
}

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

public static class DistanceCalculator
{
    // https://en.wikipedia.org/wiki/Earth_radius
    private const double EarthMeanRadiusInKilometer = 6371d;

    /// <remarks>Use the Haversine formula to calculate the distance between two points on the surface of a sphere</remarks>
    /// <seealso href="https://en.wikipedia.org/wiki/Haversine_formula" />
    public static double DistanceInKm(Wgs84Coordinate coord1, Wgs84Coordinate coord2)
    {
        var lat1 = coord1.LatitudeInDegrees * Math.PI / 180d;
        var lon1 = coord1.LongitudeInDegrees * Math.PI / 180d;
        var lat2 = coord2.LatitudeInDegrees * Math.PI / 180d;
        var lon2 = coord2.LongitudeInDegrees * Math.PI / 180d;
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
}

/// <summary>
///     Elvish plan coordinate
/// </summary>
public sealed record ElvishCoordinate(int Order, WebMercatorCoordinate Coordinate);

/// <summary>
///     Web Mercator / EPSG:3857 Coordinates in metres
/// </summary>
public sealed record WebMercatorCoordinate(double XInMeter, double YInMeter);

/// <summary>
///     WGS84 Coordinates in degrees
/// </summary>
public sealed record Wgs84Coordinate(double LongitudeInDegrees, double LatitudeInDegrees);

public static class FunctionalExtensions
{
    public static TResult Pipe<TSource, TResult>(
        this TSource source,
        Func<TSource, TResult> func)
        => func(source);
}
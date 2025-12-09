using System.Globalization;
using FluentAssertions;
using Xunit;

namespace Day09.Tests;

public class SantaJourneyCalculatorShould
{
    [Fact]
    public void Load_elvish_coordinates_from_file()
    {
        var elvishcoordinates = LoadElvishCoordinates("trace");
        elvishcoordinates.Count().Should().Be(500);
        elvishcoordinates
            .MinBy(c=>c.Order)
            .Should()
            .BeEquivalentTo(
                new ElvishCoordinate(1, new WebMercatorCoordinate(253716.21038051567d, 6234041.976798748d)));
        
        elvishcoordinates
            .MaxBy(c=>c.Order)
            .Should()
            .BeEquivalentTo(
                new ElvishCoordinate(500, new WebMercatorCoordinate(16826950.84323861d, -4016067.571985976d)));

    }

    [Fact]
    public void Convert_web_mercator_coordinate_to_WGS84()
    {
        var webMercatorCoordinate = new WebMercatorCoordinate(7714456.11274088d, 5639226.707649254d);

        var wgs84Coordinate = ToWgs84Coordinate(webMercatorCoordinate);
        wgs84Coordinate
            .Should()
            .BeEquivalentTo(new Wgs84Coordinate(69.30013834744402d, 45.11235404506074d));
    }

    // EPSG:3857 => WGS84  WGS84 (longitude/latitude en degrés)
    // R = 6378137 (m).
    // lon_deg = (x_m / R) * 180/π
    // lat_deg = (2 * atan(exp(y_m / R)) - π/2) * 180/π
    private static Wgs84Coordinate ToWgs84Coordinate(WebMercatorCoordinate webMercatorCoordinate)
    {
        const double R = 6378137d;
        var lonDeg = webMercatorCoordinate.XInMeter / R * 180d / Math.PI;
        var latDeg = (2d * Math.Atan(Math.Exp(webMercatorCoordinate.YInMeter / R)) - Math.PI / 2d) * 180d / Math.PI;

        return new Wgs84Coordinate(lonDeg, latDeg);
    }

    private static IEnumerable<ElvishCoordinate> LoadElvishCoordinates(string fileName)
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
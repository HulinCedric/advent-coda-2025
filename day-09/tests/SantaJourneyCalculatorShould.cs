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
        elvishcoordinates.First()
            .Should()
            .BeEquivalentTo(new Elvishcoordinates(146, 7714456.11274088d, 5639226.707649254d));
    }

    // EPSG:3857 => WGS84  WGS84 (longitude/latitude en degrés)
    // R = 6378137 (m).
    // lon_deg = (x_m / R) * 180/π
    // lat_deg = (2 * atan(exp(y_m / R)) - π/2) * 180/π
    [Fact]
    public void Convert_elvish_coordinate_to_WGS84()
    {
        var elvishCoordinate = new Elvishcoordinates(146, 7714456.11274088d, 5639226.707649254d);

        const double R = 6378137d;
        var lonDeg = (elvishCoordinate.XInMeter / R) * 180d / Math.PI;
        var latDeg = (2d * Math.Atan(Math.Exp(elvishCoordinate.YInMeter / R)) - Math.PI / 2d) * 180d / Math.PI;

        lonDeg.Should().BeApproximately(69.30013834744402d, 0.0000001d);
        latDeg.Should().BeApproximately(45.11235404506074d, 0.0000001d);
    }

    private static IEnumerable<Elvishcoordinates> LoadElvishCoordinates(string fileName)
    {
        var lines = File.ReadAllLines(fileName);

        return lines.Select(MapElvishCoordinate);
    }

    private static Elvishcoordinates MapElvishCoordinate(string line)
    {
        var part = line.Split(',');
        return new Elvishcoordinates(
            int.Parse(part[0], CultureInfo.InvariantCulture),
            double.Parse(part[1], CultureInfo.InvariantCulture),
            double.Parse(part[2], CultureInfo.InvariantCulture));
    }
}

/// <summary>
///     Coordinates in metres (Elfic map – Web Mercator / EPSG:3857)
/// </summary>
public sealed record Elvishcoordinates(int Order, double XInMeter, double YInMeter);
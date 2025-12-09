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
            .BeEquivalentTo(new Elvishcoordinates(146, 7714456.11274088m, 5639226.707649254m));
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
            decimal.Parse(part[1], CultureInfo.InvariantCulture),
            decimal.Parse(part[2], CultureInfo.InvariantCulture));
    }
}

public sealed record Elvishcoordinates(int Order, decimal XInMeter, decimal YInMeter);
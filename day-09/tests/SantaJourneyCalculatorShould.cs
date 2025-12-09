using System.Globalization;
using FluentAssertions;
using Xunit;

namespace Day09.Tests;

public class SantaJourneyCalculatorShould
{
    [Fact]
    public void TODO()
    {
        var elvishcoordinates = LoardElvishcoordinates("trace");
        elvishcoordinates.Count().Should().Be(500);
        elvishcoordinates.First()
            .Should()
            .BeEquivalentTo(new Elvishcoordinates(146, 7714456.11274088m, 5639226.707649254m));
    }

    private static IEnumerable<Elvishcoordinates> LoardElvishcoordinates(string trace)
    {
        var lines = File.ReadAllLines(trace);

        var elvishcoordinates = lines.Select(line =>
        {
            var part = line.Split(',');
            return new Elvishcoordinates(
                int.Parse(part[0], CultureInfo.InvariantCulture),
                decimal.Parse(part[1], CultureInfo.InvariantCulture),
                decimal.Parse(part[2], CultureInfo.InvariantCulture));
        });
        return elvishcoordinates;
    }
}

public sealed record Elvishcoordinates(int Order, decimal XInMeter, decimal YInMeter);
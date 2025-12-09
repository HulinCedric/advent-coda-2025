using System.Globalization;
using FluentAssertions;
using Xunit;

namespace Day09.Tests;

public class SantaJourneyCalculatorShould
{
    [Fact]
    public void TODO()
    {
        var lines = File.ReadAllLines("trace");
        lines.Length.Should().Be(500);

        lines.First().Should().BeEquivalentTo("146,7714456.11274088,5639226.707649254");

        lines.Select(line =>
            {
                var part = line.Split(',');
                return new Elvishcoordinates(
                    int.Parse(part[0], CultureInfo.InvariantCulture),
                    decimal.Parse(part[1], CultureInfo.InvariantCulture),
                    decimal.Parse(part[2], CultureInfo.InvariantCulture));
            })
            .First()
            .Should()
            .BeEquivalentTo(new Elvishcoordinates(146, 7714456.11274088m, 5639226.707649254m));
    }
}

public sealed record Elvishcoordinates(int Order, decimal XInMeter, decimal YInMeter);
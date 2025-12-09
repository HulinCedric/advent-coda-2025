using FluentAssertions;
using Xunit;
using static Day09.CoordinateConverter;
using static Day09.DistanceCalculator;
using static Day09.ElvishCoordinateSystemLoader;

namespace Day09.Tests;

public class SantaJourneyCalculatorShould
{
    [Fact]
    public void Calculate_santa_journey_distance_in_km()
        => LoadElvishCoordinates("trace")
            .OrderBy(c => c.Order)
            .Select(c => ToWgs84Coordinate(c.Coordinate))
            .Pipe(coords => DistanceInKm(coords.First(), coords.Last()))
            .Should()
            .BeApproximately(16969, 0.5d);
}
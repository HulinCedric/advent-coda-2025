using FluentAssertions;
using Xunit;

namespace Day09.Tests;

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
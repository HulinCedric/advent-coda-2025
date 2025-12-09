using FluentAssertions;
using Xunit;

namespace Day09.Tests;

public class CoordinateConverterShould
{
    [Fact]
    public void Convert_web_mercator_coordinate_to_WGS84()
        => CoordinateConverter.ToWgs84Coordinate(new WebMercatorCoordinate(7714456.11274088d, 5639226.707649254d))
            .Should()
            .BeEquivalentTo(new Wgs84Coordinate(69.30013834744402d, 45.11235404506074d));
}
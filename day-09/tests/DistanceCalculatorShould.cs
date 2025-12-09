using FluentAssertions;
using Xunit;

namespace Day09.Tests;

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
            .BeApproximately(340.553d, 0.001d);

    [Fact]
    public void Provide_zero_distance_for_same_coordinate()
        => DistanceCalculator.DistanceInKm(ParisEiffelTowerCoordinate, ParisEiffelTowerCoordinate)
            .Should()
            .BeApproximately(0, 0.1d);
}
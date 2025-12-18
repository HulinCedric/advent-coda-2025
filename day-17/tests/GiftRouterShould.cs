using Xunit;

namespace Routing.Tests;

public class GiftRouterTests
{
    [Fact(DisplayName = "Null gift -> ERROR")]
    public void NullGift_ReturnsError() => Assert.Equal("ERROR", GiftRouter.Route(null));

    [Theory(DisplayName = "Empty/blank zone -> WORKSHOP-HOLD")]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("   ")]
    [InlineData("\t")]
    public void EmptyOrBlankZone_ReturnsHold(string? zone)
        => Assert.Equal("WORKSHOP-HOLD", GiftRouter.Route(new Gift(1.0, false, zone)));

    [Theory(DisplayName = "Routing matrix (no null/blank zone)")]
    [InlineData(2.0,  true,  "EU",   "REINDEER-EXPRESS")]
    [InlineData(2.1,  true,  "EU",   "SLED")]
    [InlineData(10.1, false, "EU",   "SLED")]
    [InlineData(9.9,  false, "EU",   "REINDEER-EXPRESS")]
    [InlineData(9.9,  false, "NA",   "REINDEER-EXPRESS")]
    [InlineData(9.9,  false, "APAC", "SLED")]
    public void RoutingMatrix(double weightKg, bool fragile, string zone, string expectedRoute)
        => Assert.Equal(expectedRoute, GiftRouter.Route(new Gift(weightKg, fragile, zone)));
}

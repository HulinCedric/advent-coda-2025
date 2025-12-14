using FluentAssertions;
using Xunit;

namespace Day14.Tests;

public class SantaShould
{
    [Fact]
    public void Deliver_to_starting_house()
    {
        // Arrange
        var instructions = "NNESESW";

        // Act
        var uniqueHouses = DeliveryCounter.CountUniqueHouses(instructions);

        // Assert
        uniqueHouses.Should().Be(8);
    }
}

public static class DeliveryCounter
{
    public static int CountUniqueHouses(string instructions)
    {
        return 1;
    }
}


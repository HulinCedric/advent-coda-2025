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
    public static int CountUniqueHouses(string instructions) => 1;
}

public class SleighShould
{
    [Fact]
    public void Start_at_initial_point() => new Sleigh().CurrentHouse().Should().Be(new HouseLocation(0, 0));
}

public class Sleigh
{
    public HouseLocation CurrentHouse() => new(0, 0);
}

public record HouseLocation(int X, int Y);
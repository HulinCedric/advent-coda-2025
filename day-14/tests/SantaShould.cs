using FluentAssertions;
using Xunit;

namespace Day14.Tests;

public class SantaShould
{
    [Theory]
    [InlineData("", 1)]
    [InlineData("N", 2)]
    [InlineData("NNESESW", 8)]
    [InlineData("NNSS", 3)]
    public void Count_unique_houses(string instructions, int expectedUniqueHouses)
        => DeliveryCounter.CountUniqueHouses(instructions).Should().Be(expectedUniqueHouses);
}

public static class DeliveryCounter
{
    public static int CountUniqueHouses(string instructions)
    {
        var sleigh = new Sleigh();
        var visitedHouses = new HashSet<HouseLocation> { sleigh.CurrentHouse() };

        foreach (var instruction in instructions)
        {
            sleigh = sleigh.MoveTo(instruction);
            visitedHouses.Add(sleigh.CurrentHouse());
        }

        return visitedHouses.Count;
    }
}

public class SleighShould
{
    [Fact]
    public void Start_at_initial_point() => new Sleigh().CurrentHouse().Should().Be(new HouseLocation(0, 0));

    [Fact]
    public void Move_to_north()
    {
        // Arrange
        var sleigh = new Sleigh(new HouseLocation(0, 0));

        // Act
        var movedSleigh = sleigh.MoveTo('N');

        // Assert
        movedSleigh.CurrentHouse().Should().Be(new HouseLocation(0, 1));
    }

    [Fact]
    public void Move_to_south()
    {
        // Arrange
        var sleigh = new Sleigh(new HouseLocation(0, 0));

        // Act
        var movedSleigh = sleigh.MoveTo('S');

        // Assert
        movedSleigh.CurrentHouse().Should().Be(new HouseLocation(0, -1));
    }

    [Fact]
    public void Move_to_east()
    {
        // Arrange
        var sleigh = new Sleigh(new HouseLocation(0, 0));

        // Act
        var movedSleigh = sleigh.MoveTo('E');

        // Assert
        movedSleigh.CurrentHouse().Should().Be(new HouseLocation(1, 0));
    }

    [Fact]
    public void Move_to_west()
    {
        // Arrange
        var sleigh = new Sleigh(new HouseLocation(0, 0));

        // Act
        var movedSleigh = sleigh.MoveTo('W');

        // Assert
        movedSleigh.CurrentHouse().Should().Be(new HouseLocation(-1, 0));
    }
}

public record Sleigh
{
    private readonly HouseLocation _houseLocation;

    public Sleigh() => _houseLocation = new HouseLocation(0, 0);
    public Sleigh(HouseLocation houseLocation) => _houseLocation = houseLocation;

    public HouseLocation CurrentHouse() => _houseLocation;

    public Sleigh MoveTo(char c)
        => c switch
        {
            'N' => new Sleigh(_houseLocation.ToNorth()),
            'S' => new Sleigh(_houseLocation with { Y = _houseLocation.Y - 1 }),
            'E' => new Sleigh(_houseLocation with { X = _houseLocation.X + 1 }),
            'W' => new Sleigh(_houseLocation with { X = _houseLocation.X - 1 }),
            _ => this
        };
}

public record HouseLocation(int X, int Y)
{
    public HouseLocation ToNorth() => this with { Y = Y + 1 };
}
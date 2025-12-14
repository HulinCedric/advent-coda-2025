using FluentAssertions;
using Xunit;

namespace Day14.Tests;

public class SleighShould
{
    [Fact]
    public void Start_at_initial_point() => Sleigh.Start().CurrentHouse().Should().Be(new HouseLocation(0, 0));

    [Fact]
    public void Move_to_north()
    {
        // Arrange
        var sleigh = Sleigh.Start();

        // Act
        var movedSleigh = sleigh.MoveTo('N');

        // Assert
        movedSleigh.CurrentHouse().Should().Be(new HouseLocation(0, 1));
    }

    [Fact]
    public void Move_to_south()
    {
        // Arrange
        var sleigh = Sleigh.Start();

        // Act
        var movedSleigh = sleigh.MoveTo('S');

        // Assert
        movedSleigh.CurrentHouse().Should().Be(new HouseLocation(0, -1));
    }

    [Fact]
    public void Move_to_east()
    {
        // Arrange
        var sleigh = Sleigh.Start();

        // Act
        var movedSleigh = sleigh.MoveTo('E');

        // Assert
        movedSleigh.CurrentHouse().Should().Be(new HouseLocation(1, 0));
    }

    [Fact]
    public void Move_to_west()
    {
        // Arrange
        var sleigh = Sleigh.Start();

        // Act
        var movedSleigh = sleigh.MoveTo('W');

        // Assert
        movedSleigh.CurrentHouse().Should().Be(new HouseLocation(-1, 0));
    }
}
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
        => Sleigh.Start()
            .FollowInstructions(instructions)
            .VisitedHouses()
            .Count.Should()
            .Be(expectedUniqueHouses);
}

public class SleighShould
{
    [Fact]
    public void Start_at_initial_point() => Sleigh.Start().CurrentHouse().Should().Be(new HouseLocation(0, 0));

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
    private readonly IReadOnlySet<HouseLocation> _visitedHouses;

    private Sleigh() : this(new HouseLocation(0, 0))
    {
    }

    public Sleigh(HouseLocation houseLocation) : this(houseLocation, new HashSet<HouseLocation>())
    {
    }

    private Sleigh(HouseLocation houseLocation, IReadOnlySet<HouseLocation> visitedHouses)
    {
        _houseLocation = houseLocation;
        _visitedHouses = new HashSet<HouseLocation>(visitedHouses) { houseLocation };
    }

    public static Sleigh Start() => new();

    public Sleigh FollowInstructions(string instructions)
        => instructions.Aggregate(this, (sleigh, instruction) => sleigh.MoveTo(instruction));

    public HouseLocation CurrentHouse() => _houseLocation;

    public Sleigh MoveTo(char instruction) => new(_houseLocation.MoveTo(instruction), _visitedHouses);

    public IReadOnlySet<HouseLocation> VisitedHouses() => _visitedHouses;
}

public record HouseLocation(int X, int Y)
{
    private HouseLocation ToNorth() => this with { Y = Y + 1 };
    private HouseLocation ToSouth() => this with { Y = Y - 1 };
    private HouseLocation ToEast() => this with { X = X + 1 };
    private HouseLocation ToWest() => this with { X = X - 1 };

    public HouseLocation MoveTo(char instruction)
        => instruction switch
        {
            'N' => ToNorth(),
            'S' => ToSouth(),
            'E' => ToEast(),
            'W' => ToWest(),
            _ => this
        };
}
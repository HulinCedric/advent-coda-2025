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
    public void Count_visited_houses(string instructions, int visitedHousesNumber)
        => Sleigh.Start()
            .FollowInstructions(instructions)
            .VisitedHousesNumber()
            .Should()
            .Be(visitedHousesNumber);

    [Fact]
    public void Count_visited_houses_from_input_instruction()
        => Sleigh.Start()
            .FollowInstructions(File.ReadAllText("steps"))
            .VisitedHousesNumber()
            .Should()
            .Be(5260);
}

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

public record Sleigh
{
    private readonly HouseLocation _houseLocation;
    private readonly IReadOnlySet<HouseLocation> _visitedHouses;

    private Sleigh(HouseLocation houseLocation, IReadOnlySet<HouseLocation> visitedHouses)
    {
        _houseLocation = houseLocation;
        _visitedHouses = new HashSet<HouseLocation>(visitedHouses) { houseLocation };
    }

    public static Sleigh Start() => new(HouseLocation.StartingHouse(), new HashSet<HouseLocation>());

    public Sleigh FollowInstructions(string instructions)
        => instructions.Aggregate(this, (sleigh, instruction) => sleigh.MoveTo(instruction));

    public HouseLocation CurrentHouse() => _houseLocation;

    public Sleigh MoveTo(char instruction) => new(_houseLocation.MoveTo(instruction), _visitedHouses);

    public int VisitedHousesNumber() => _visitedHouses.Count;
}

public record HouseLocation(int X, int Y)
{
    public static HouseLocation StartingHouse() => new(0, 0);

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
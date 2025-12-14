using System.Collections.Immutable;

namespace Day14;

public record Sleigh
{
    private readonly HouseLocation _houseLocation;
    private readonly ImmutableHashSet<HouseLocation> _visitedHouses;

    private Sleigh(HouseLocation houseLocation, ImmutableHashSet<HouseLocation> visitedHouses)
    {
        _houseLocation = houseLocation;
        _visitedHouses = visitedHouses.Add(houseLocation);
    }

    public static Sleigh Start() => new(HouseLocation.StartingHouse(), ImmutableHashSet.Create<HouseLocation>());

    public Sleigh FollowInstructions(string instructions)
        => instructions.Aggregate(this, (sleigh, instruction) => sleigh.MoveTo(instruction));

    public Sleigh MoveTo(char instruction) => new(_houseLocation.MoveTo(instruction), _visitedHouses);

    public HouseLocation CurrentHouse() => _houseLocation;

    public int VisitedHousesNumber() => _visitedHouses.Count;
}
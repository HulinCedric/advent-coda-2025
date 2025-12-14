namespace Day14;

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

    public Sleigh MoveTo(char instruction) => new(_houseLocation.MoveTo(instruction), _visitedHouses);

    public HouseLocation CurrentHouse() => _houseLocation;
    
    public int VisitedHousesNumber() => _visitedHouses.Count;
}
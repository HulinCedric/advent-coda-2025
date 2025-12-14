namespace Day14;

public record HouseLocation(int X, int Y)
{
    internal static HouseLocation StartingHouse() => new(0, 0);

    internal HouseLocation MoveTo(char instruction)
        => instruction switch
        {
            'N' => ToNorth(),
            'S' => ToSouth(),
            'E' => ToEast(),
            'W' => ToWest(),
            _ => this
        };

    private HouseLocation ToNorth() => this with { Y = Y + 1 };
    private HouseLocation ToSouth() => this with { Y = Y - 1 };
    private HouseLocation ToEast() => this with { X = X + 1 };
    private HouseLocation ToWest() => this with { X = X - 1 };
}
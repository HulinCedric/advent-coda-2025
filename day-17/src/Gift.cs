namespace Routing;

public record Gift
{
    private readonly PotentialZone _zone;

    public Gift(double WeightKg, bool Fragile, string? zone)
    {
        this.WeightKg = WeightKg;
        this.Fragile = Fragile;
        _zone = new PotentialZone(zone);
    }

    public double WeightKg { get; init; }
    public bool Fragile { get; init; }

    public override string ToString() => $"Gift{{w={WeightKg}, fragile={Fragile}, zone='{_zone}'}}";

    public bool DoesNotHaveZone() => _zone.IsNotDefined();

    public bool TargetAlmostAZone(params string[] targetZones)
        => targetZones.Any(targetZone => _zone.IsSame(targetZone));

    public bool IsFragile() => Fragile;
    public bool IsNonFragile() => !IsFragile();
}

public record PotentialZone(string? Value)
{
    public bool IsNotDefined() => string.IsNullOrWhiteSpace(Value);

    public bool IsSame(string zone) => Value == zone;
}
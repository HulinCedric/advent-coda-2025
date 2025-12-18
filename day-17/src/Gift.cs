namespace Routing;

public record Gift
{
    private readonly bool _fragile;
    private readonly WeightKg _weight;
    private readonly PotentialZone _zone;

    public Gift(double weightKg, bool fragile, string? zone)
    {
        _weight = new WeightKg(weightKg);
        _fragile = fragile;
        _zone = new PotentialZone(zone);
    }

    public bool DoesNotHaveZone() => _zone.IsNotDefined();

    public bool TargetAlmostAZone(params string[] targetZones)
        => targetZones.Any(targetZone => _zone.IsSame(targetZone));

    public bool IsFragile() => _fragile;
    public bool IsLight() => _weight.IsLight();
    public bool IsHeavy() => _weight.IsHeavy();

    public override string ToString() => $"Gift{{w={_weight}, fragile={_fragile}, zone='{_zone}'}}";
}

public record WeightKg(double Value)
{
    public bool IsLight() => Value <= 2.0;
    public bool IsHeavy() => Value > 10.0;
}

public record PotentialZone(string? Value)
{
    public bool IsNotDefined() => string.IsNullOrWhiteSpace(Value);

    public bool IsSame(string zone) => Value == zone;
}
namespace Routing;

public record Gift
{
    private readonly Fragility _fragility;
    private readonly WeightKg _weight;
    private readonly PotentialZone _zone;

    public Gift(double weightKg, bool fragile, string? zone)
    {
        _weight = new WeightKg(weightKg);
        _fragility = new Fragility(fragile);
        _zone = new PotentialZone(zone);
    }

    public bool ZoneIsNotDefined() => _zone.IsNotDefined();
    public bool IsFragile() => _fragility.IsFragile();
    public bool IsLight() => _weight.IsLight();
    public bool IsHeavy() => _weight.IsHeavy();
    public bool TargetExpressZone() => _zone.IsExpress();

    public override string ToString() => $"Gift{{w={_weight}, fragile={_fragility}, zone='{_zone}'}}";
}

public record WeightKg(double Value)
{
    private const double LightWeight = 2.0;
    private const double HeavyWeight = 10.0;

    public bool IsLight() => Value <= LightWeight;

    public bool IsHeavy() => Value > HeavyWeight;
}

public record Fragility(bool Value)
{
    public bool IsFragile() => Value;
}

public record PotentialZone(string? Value)
{
    private const string Europe = "EU";
    private const string NotApplicable = "NA";

    public bool IsNotDefined() => string.IsNullOrWhiteSpace(Value);

    public bool IsExpress() => Value is Europe or NotApplicable;
}
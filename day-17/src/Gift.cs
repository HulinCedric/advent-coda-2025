namespace Routing;

public record Gift(double WeightKg, bool Fragile, string? Zone)
{
    public override string ToString()
        => $"Gift{{w={WeightKg}, fragile={Fragile}, zone='{Zone}'}}";

    public bool DoesNotHadZone() => this is { Zone: var zone } && string.IsNullOrWhiteSpace(zone);
}
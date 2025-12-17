namespace Routing;

public record Gift(double WeightKg, bool Fragile, string? Zone)
{
    public override string ToString()
        => $"Gift{{w={WeightKg}, fragile={Fragile}, zone='{Zone}'}}";
}
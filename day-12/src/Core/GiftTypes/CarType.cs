namespace GiftMachine.Core.GiftTypes;

public sealed record CarType() : GiftType("car")
{
    public override string BuildFor(string recipient) => $"🚗 Petite voiture pour {recipient}";
}
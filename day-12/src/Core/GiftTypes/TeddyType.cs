namespace GiftMachine.Core.GiftTypes;

public sealed record TeddyType() : GiftType("teddy")
{
    public override string BuildFor(string recipient) => $"🧸 Ourson en peluche pour {recipient}";
}
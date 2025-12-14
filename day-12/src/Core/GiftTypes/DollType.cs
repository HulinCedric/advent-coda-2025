namespace GiftMachine.Core.GiftTypes;

public sealed record DollType() : GiftType("doll")
{
    public override string BuildFor(string recipient) => $"🪆 Poupée magique pour {recipient}";
}
namespace GiftMachine.Core.GiftTypes;

public sealed record RobotType() : GiftType("robot")
{
    public override string BuildFor(string recipient) => $"🤖 Robot futuriste pour {recipient}";
}
namespace GiftMachine.Core.GiftBuilders;

public class RobotBuilder : IGiftBuilder
{
    public string BuildFor(string recipient) => $"🤖 Robot futuriste pour {recipient}";
}
namespace GiftMachine.Core.GiftBuilders;

public class DollBuilder : IGiftBuilder
{
    public string BuildFor(string recipient) => $"🪆 Poupée magique pour {recipient}";
}
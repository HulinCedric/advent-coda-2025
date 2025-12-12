namespace GiftMachine.Core.GiftBuilders;

public class TeddyBuilder : IGiftBuilder
{
    public string BuildFor(string recipient) => $"🧸 Ourson en peluche pour {recipient}";
}
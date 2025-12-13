namespace GiftMachine.Core.GiftBuilders;

public class BookBuilder : IGiftBuilder
{
    public string BuildFor(string recipient) => $"📚 Livre enchanté pour {recipient}";
}
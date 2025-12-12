namespace GiftMachine;

public class BookBuilder : IGiftBuilder
{
    public string BuildFor(string recipient) => $"📚 Livre enchanté pour {recipient}";
}
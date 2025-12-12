namespace GiftMachine;

public class TeddyBuilder : IGiftBuilder
{
    public string BuildFor(string recipient) => $"🧸 Ourson en peluche pour {recipient}";
}
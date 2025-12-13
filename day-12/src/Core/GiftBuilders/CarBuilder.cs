namespace GiftMachine.Core.GiftBuilders;

public class CarBuilder : IGiftBuilder
{
    public string BuildFor(string recipient) => $"🚗 Petite voiture pour {recipient}";
}
namespace GiftMachine;

public class GiftFactory : IGiftFactory
{
    private readonly ILogger _logger;

    public GiftFactory(ILogger logger)
    {
        _logger = logger;
    }

    public string BuildGift(string type, string recipient)
    {
        _logger.Log($"Construction du cadeau de type '{type}'...");

        return type switch
        {
            "teddy" => $"🧸 Ourson en peluche pour {recipient}",
            "car" => $"🚗 Petite voiture pour {recipient}",
            "doll" => $"🪆 Poupée magique pour {recipient}",
            "book" => $"📚 Livre enchanté pour {recipient}",
            _ => throw new Exception($"Type de cadeau '{type}' non reconnu !")
        };
    }
}
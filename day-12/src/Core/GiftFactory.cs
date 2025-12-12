using GiftMachine.Core.GiftBuilders;

namespace GiftMachine.Core;

public class GiftFactory : IGiftFactory
{
    private readonly IReadOnlyDictionary<string, IGiftBuilder> _giftBuilders;
    private readonly ILogger _logger;

    public GiftFactory(ILogger logger, IReadOnlyDictionary<string, IGiftBuilder> giftBuilders)
    {
        _logger = logger;
        _giftBuilders = giftBuilders;
    }

    public string BuildGift(string type, string recipient)
    {
        _logger.Log($"Construction du cadeau de type '{type}'...");

        if (!_giftBuilders.TryGetValue(type, out var giftBuilder))
            throw new Exception($"Type de cadeau '{type}' non reconnu !");

        return giftBuilder.BuildFor(recipient);
    }
}
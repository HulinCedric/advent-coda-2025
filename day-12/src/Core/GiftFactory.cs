using GiftMachine.Core.GiftBuilders;

namespace GiftMachine.Core;

public class GiftFactory : IGiftFactory
{
    private readonly IReadOnlyDictionary<string, IGiftBuilder> _giftBuilders;

    public GiftFactory(IReadOnlyDictionary<string, IGiftBuilder> giftBuilders) => _giftBuilders = giftBuilders;

    public string BuildGift(string type, string recipient)
    {
        if (!_giftBuilders.TryGetValue(type, out var giftBuilder))
            throw new Exception($"Type de cadeau '{type}' non reconnu !");

        return giftBuilder.BuildFor(recipient);
    }
}
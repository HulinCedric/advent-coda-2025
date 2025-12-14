using GiftMachine.Core.GiftTypes;

namespace GiftMachine.Core;

public class GiftFactory : IGiftFactory
{
    public string BuildGift(GiftType type, string recipient) => type.BuildFor(recipient);
}
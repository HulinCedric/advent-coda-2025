using GiftMachine.Core.GiftTypes;

namespace GiftMachine.Core;

public interface IGiftFactory
{
    string BuildGift(GiftType type, string recipient);
}
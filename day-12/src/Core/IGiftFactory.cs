namespace GiftMachine.Core;

public interface IGiftFactory
{
    string BuildGift(string type, string recipient);
}
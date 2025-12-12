namespace GiftMachine;

public interface IGiftFactory
{
    string BuildGift(string type, string recipient);
}
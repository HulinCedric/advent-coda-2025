namespace GiftMachine.Core;

public interface IDeliveryService
{
    void DeliverGift(string gift, string recipient);
}
namespace GiftMachine.Core;

public class DeliveryService : IDeliveryService
{
    private readonly ISledgeDeliveryService _sledgeDeliveryService;

    public DeliveryService(ISledgeDeliveryService sledgeDeliveryService)
        => _sledgeDeliveryService = sledgeDeliveryService;

    public void DeliverGift(string gift, string recipient)
    {
        Thread.Sleep(4);

        _sledgeDeliveryService.Deliver();
    }
}
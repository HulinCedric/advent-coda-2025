namespace GiftMachine.Core;

public class DeliveryService : IDeliveryService
{
    private readonly ILogger _logger;
    private readonly ISledgeDeliveryService _sledgeDeliveryService;

    public DeliveryService(ILogger logger, ISledgeDeliveryService sledgeDeliveryService)
    {
        _logger = logger;
        _sledgeDeliveryService = sledgeDeliveryService;
    }

    public void DeliverGift(string gift, string recipient)
    {
       
        Thread.Sleep(4);

        _sledgeDeliveryService.Deliver();

    }
}
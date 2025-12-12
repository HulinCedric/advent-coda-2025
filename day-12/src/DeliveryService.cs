namespace GiftMachine;

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
        _logger.Log("Livraison en cours vers l'atelier de distribution...");
        Thread.Sleep(4);

        _sledgeDeliveryService.Deliver();

        _logger.Log($"Cadeau livré à la zone d’expédition pour {recipient}");
    }
}
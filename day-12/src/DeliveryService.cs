namespace GiftMachine;

public class DeliveryService : IDeliveryService
{
    private readonly ILogger _logger;

    public DeliveryService(ILogger logger)
    {
        _logger = logger;
    }

    public void DeliverGift(string gift, string recipient)
    {
        _logger.Log("Livraison en cours vers l'atelier de distribution...");
        Thread.Sleep(4);

        // Pour l'exercice, on simule une erreur avec 1 chance sur 5 environ
        Random rnd = new Random();
        if (rnd.Next(0, 11) > 8)
        {
            throw new Exception("Erreur de livraison : le traîneau est tombé en panne.");
        }

        _logger.Log($"Cadeau livré à la zone d’expédition pour {recipient}");
    }
}
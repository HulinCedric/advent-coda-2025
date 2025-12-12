namespace GiftMachine.Core;

public class DeliveryService : IDeliveryService
{
    private readonly IRandomFactory _randomFactory;

    public DeliveryService(IRandomFactory randomFactory) => _randomFactory = randomFactory;

    public void DeliverGift(string gift, string recipient)
    {
        Thread.Sleep(4);

        // Pour l'exercice, on simule une erreur avec 1 chance sur 5 environ
        var rnd = _randomFactory.GetRandom();
        if (rnd.Next(0, 11) > 8) throw new Exception("Erreur de livraison : le traîneau est tombé en panne.");
    }
}
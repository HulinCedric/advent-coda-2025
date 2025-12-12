using GiftMachine.Core;

namespace GiftMachine.Infrastructure.ExternalSystems;

public class SledgeDeliveryService : ISledgeDeliveryService
{
    private readonly IRandomFactory _randomFactory;

    public SledgeDeliveryService(IRandomFactory randomFactory)
    {
        _randomFactory = randomFactory;
    }

    // Pour l'exercice, on simule une erreur avec 1 chance sur 5 environ
    public void Deliver()
    {
        Random rnd = _randomFactory.GetRandom();
        if (rnd.Next(0, 11) > 8)
        {
            throw new Exception("Erreur de livraison : le traîneau est tombé en panne.");
        }
    }
}
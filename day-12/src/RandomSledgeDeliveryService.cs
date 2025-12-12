namespace GiftMachine;

public class RandomSledgeDeliveryService : ISledgeDeliveryService
{
    // Pour l'exercice, on simule une erreur avec 1 chance sur 5 environ
    public void Deliver()
    {
        Random rnd = new Random();
        if (rnd.Next(0, 11) > 8)
        {
            throw new Exception("Erreur de livraison : le traîneau est tombé en panne.");
        }
    }
}
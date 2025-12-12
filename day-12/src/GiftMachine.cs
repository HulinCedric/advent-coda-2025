namespace GiftMachine;

public class GiftMachine
{
    private readonly ILogger _logger;
    private readonly IGiftFactory _giftFactory;
    private readonly IGiftWrapper _giftWrapper;

    public GiftMachine(ILogger logger, IGiftFactory giftFactory, GiftWrapper giftWrapper)
    {
        _logger = logger;
        _giftFactory = giftFactory;
        _giftWrapper = giftWrapper;
    }

    public string CreateGift(string type, string recipient)
    {
        try
        {
            _logger.Log($"Démarrage de la création du cadeau pour {recipient}");

            string gift = _giftFactory.BuildGift(type, recipient);

            _giftWrapper.WrapGift(gift);
            AddRibbon(gift);
            DeliverGift(gift, recipient);

            _logger.Log($"Cadeau prêt pour {recipient} : {gift}");
            return gift;
        }
        catch (Exception ex)
        {
            DisplayError(ex.Message);
            return $"Échec de la création du cadeau pour {recipient}";
        }
    }

    private void AddRibbon(string gift)
    {
        _logger.Log($"Ajout du ruban magique sur : {gift}");
        Thread.Sleep(2);
    }

    private void DeliverGift(string gift, string recipient)
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

    private void DisplayError(string message)
    {
        _logger.Log("🚨 ERREUR CRITIQUE 🚨");
        _logger.Log($"❌ {message}");
        _logger.Log("🔴 Merci de respecter les principes SOLID");
    }
}
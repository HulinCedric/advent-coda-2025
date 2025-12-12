namespace GiftMachine;

public interface ILogger
{
    void Log(string message);
}

public class Logger : ILogger
{
    public void Log(string message)
    {
        string time = DateTime.Now.ToString("HH:mm:ss");
        Console.WriteLine($"[{time}] {message}");
    }
}

public class GiftMachine
{
    private readonly ILogger _logger = new Logger();

    public string CreateGift(string type, string recipient)
    {
        try
        {
            _logger.Log($"Démarrage de la création du cadeau pour {recipient}");

            string gift = BuildGift(type, recipient);

            WrapGift(gift);
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

    private string BuildGift(string type, string recipient)
    {
        _logger.Log($"Construction du cadeau de type '{type}'...");

        return type switch
        {
            "teddy" => $"🧸 Ourson en peluche pour {recipient}",
            "car" => $"🚗 Petite voiture pour {recipient}",
            "doll" => $"🪆 Poupée magique pour {recipient}",
            "book" => $"📚 Livre enchanté pour {recipient}",
            _ => throw new Exception($"Type de cadeau '{type}' non reconnu !")
        };
    }

    private void WrapGift(string gift)
    {
        _logger.Log($"Emballage du cadeau : {gift}");
        Thread.Sleep(3); // Petite pause simulée (3 ms)
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

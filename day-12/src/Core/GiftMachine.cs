using GiftMachine.Core.GiftTypes;

namespace GiftMachine.Core;

public class GiftMachine
{
    private readonly ILogger _logger;
    private readonly IGiftFactory _giftFactory;
    private readonly IGiftWrapper _giftWrapper;
    private readonly IRibbonService _ribbonService;
    private readonly IDeliveryService _deliveryService;

    public GiftMachine(
        ILogger logger,
        IGiftFactory giftFactory,
        IGiftWrapper giftWrapper,
        IRibbonService ribbonService,
        IDeliveryService deliveryService)
    {
        _logger = logger;
        _deliveryService = deliveryService;
        _ribbonService = ribbonService;
        _giftFactory = giftFactory;
        _giftWrapper = giftWrapper;
    }

    public string CreateGift(GiftType type, string recipient)
    {
        try
        {
            _logger.Log($"Démarrage de la création du cadeau pour {recipient}");

            _logger.Log($"Construction du cadeau de type '{type}'...");
            string gift = _giftFactory.BuildGift(type, recipient);

            _logger.Log($"Emballage du cadeau : {gift}");
            _giftWrapper.WrapGift(gift);

            _logger.Log($"Ajout du ruban magique sur : {gift}");
            _ribbonService.AddRibbon(gift);

            _logger.Log("Livraison en cours vers l'atelier de distribution...");
            _deliveryService.DeliverGift(gift, recipient);
            _logger.Log($"Cadeau livré à la zone d’expédition pour {recipient}");

            _logger.Log($"Cadeau prêt pour {recipient} : {gift}");
            return gift;
        }
        catch (Exception ex)
        {
            DisplayError(ex.Message);
            return $"Échec de la création du cadeau pour {recipient}";
        }
    }

    private void DisplayError(string message)
    {
        _logger.Log("🚨 ERREUR CRITIQUE 🚨");
        _logger.Log($"❌ {message}");
        _logger.Log("🔴 Merci de respecter les principes SOLID");
    }
}
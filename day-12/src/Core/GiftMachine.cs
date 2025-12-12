namespace GiftMachine.Core;

public class GiftMachine
{
    private readonly ILogger _logger;
    private readonly IGiftFactory _giftFactory;
    private readonly IGiftWrapper _giftWrapper;
    private readonly IRibbonService _ribbonService;
    private readonly IDeliveryService _deliveryService;

    public GiftMachine(ILogger logger, IGiftFactory giftFactory, IGiftWrapper giftWrapper, IRibbonService ribbonService, IDeliveryService deliveryService)
    {
        _logger = logger;
        _deliveryService = deliveryService;
        _ribbonService = ribbonService;
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
            _ribbonService.AddRibbon(gift);
            _deliveryService.DeliverGift(gift, recipient);

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
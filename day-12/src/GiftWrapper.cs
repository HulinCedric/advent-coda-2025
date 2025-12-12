namespace GiftMachine;

public class GiftWrapper : IGiftWrapper
{
    private readonly ILogger _logger;

    public GiftWrapper(ILogger logger)
    {
        _logger = logger;
    }

    public void WrapGift(string gift)
    {
        _logger.Log($"Emballage du cadeau : {gift}");
        Thread.Sleep(3); // Petite pause simulée (3 ms)
    }
}
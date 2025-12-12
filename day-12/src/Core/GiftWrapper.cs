namespace GiftMachine.Core;

public class GiftWrapper : IGiftWrapper
{
    private readonly ILogger _logger;

    public GiftWrapper(ILogger logger)
    {
        _logger = logger;
    }

    public void WrapGift(string gift)
    {
        Thread.Sleep(3); // Petite pause simulée (3 ms)
    }
}
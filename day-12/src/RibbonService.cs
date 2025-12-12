namespace GiftMachine;

public class RibbonService : IRibbonService
{
    private readonly ILogger _logger;

    public RibbonService(ILogger logger)
    {
        _logger = logger;
    }

    public void AddRibbon(string gift)
    {
        _logger.Log($"Ajout du ruban magique sur : {gift}");
        Thread.Sleep(2);
    }
}
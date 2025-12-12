namespace GiftMachine.Core;

public class RibbonService : IRibbonService
{
    private readonly ILogger _logger;

    public RibbonService(ILogger logger)
    {
        _logger = logger;
    }

    public void AddRibbon(string gift)
    {
        Thread.Sleep(2);
    }
}
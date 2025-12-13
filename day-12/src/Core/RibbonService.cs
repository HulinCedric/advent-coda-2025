namespace GiftMachine.Core;

public class RibbonService : IRibbonService
{
    public void AddRibbon(string gift) => Thread.Sleep(2);
}
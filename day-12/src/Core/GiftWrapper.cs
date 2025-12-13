namespace GiftMachine.Core;

public class GiftWrapper : IGiftWrapper
{
    public void WrapGift(string gift) => Thread.Sleep(3); // Petite pause simulée (3 ms)
}
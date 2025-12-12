using GiftMachine.Core;

namespace GiftMachine.Tests.TestDoubles;

public class FakeDeliveryService : IDeliveryService
{
    private string _failureReason = string.Empty;
    private bool _shouldFailToDeliver;

    public void DeliverGift(string gift, string recipient)
    {
        if (_shouldFailToDeliver) throw new Exception(_failureReason);
    }

    public void WillFailToDeliver(string failureReason)
    {
        _failureReason = failureReason;
        _shouldFailToDeliver = true;
    }
}
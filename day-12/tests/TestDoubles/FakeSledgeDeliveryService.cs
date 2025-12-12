using GiftMachine.Core;

namespace GiftMachine.Tests.TestDoubles;

public class FakeSledgeDeliveryService : ISledgeDeliveryService
{
    private string _failureReason = string.Empty;
    private bool _shouldFailToDeliver;

    public void Deliver()
    {
        if (_shouldFailToDeliver) throw new Exception(_failureReason);
    }

    public void WillFailToDeliver(string failureReason)
    {
        _failureReason = failureReason;
        _shouldFailToDeliver = true;
    }
}
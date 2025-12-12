using FluentAssertions;
using GiftMachine.Infrastructure.ExternalSystems;
using GiftMachine.Tests.TestDoubles;
using Xunit;
using static FluentAssertions.FluentActions;

namespace GiftMachine.Tests;

public class SledgeDeliveryServiceShould
{
    private readonly FakeRandomFactory _randomFactory = new();
    private readonly SledgeDeliveryService _sledgeDeliveryService;

    public SledgeDeliveryServiceShould() => _sledgeDeliveryService = new SledgeDeliveryService(_randomFactory);

    [Fact]
    public void DeliverGiftWithSuccess()
    {
        _randomFactory.WillProvideRandomWithSeed(42);

        Invoking(() => _sledgeDeliveryService.Deliver())
            .Should()
            .NotThrow();
    }

    [Fact]
    public void ThrowExceptionWhenDeliveryFailed()
    {
        _randomFactory.WillProvideRandomWithSeed(8);

        Invoking(() => _sledgeDeliveryService.Deliver())
            .Should()
            .Throw<Exception>()
            .Which.Message.Should()
            .Be("Erreur de livraison : le traîneau est tombé en panne.");
    }
}
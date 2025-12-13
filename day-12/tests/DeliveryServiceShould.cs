using FluentAssertions;
using GiftMachine.Core;
using GiftMachine.Tests.TestDoubles;
using Xunit;
using static FluentAssertions.FluentActions;

namespace GiftMachine.Tests;

public class DeliveryServiceShould
{
    private const string Gift = "🎁 Cadeau spécial pour John";
    private const string Recipient = "John";

    private readonly DeliveryService _deliveryService;
    private readonly FakeRandomFactory _randomFactory = new();

    public DeliveryServiceShould() => _deliveryService = new DeliveryService(_randomFactory);

    [Fact]
    public void DeliverGiftWithSuccess()
    {
        _randomFactory.WillProvideRandomWithSeed(42);

        Invoking(DeliverGift)
            .Should()
            .NotThrow();
    }

    [Fact]
    public void ThrowExceptionWhenDeliveryFailed()
    {
        _randomFactory.WillProvideRandomWithSeed(8);

        Invoking(DeliverGift)
            .Should()
            .Throw<Exception>()
            .Which.Message.Should()
            .Be("Erreur de livraison : le traîneau est tombé en panne.");
    }

    private void DeliverGift() => _deliveryService.DeliverGift(Gift, Recipient);
}
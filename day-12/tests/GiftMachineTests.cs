using FluentAssertions;
using Xunit;

namespace GiftMachine.Tests;

public class GiftMachineTests
{
    [Fact]
    public void GiftMachineShould()
    {
        var logger = new ConsoleLogger();
        var sledgeDeliveryService = new SledgeDeliveryService();
       
        var giftFactory = new GiftFactory(logger);
        var giftWrapper = new GiftWrapper(logger);
        var ribbonService = new RibbonService(logger);
       
        var deliveryService = new DeliveryService(logger, sledgeDeliveryService);
        var machine = new GiftMachine(logger, giftFactory, giftWrapper, ribbonService, deliveryService);

        var cadeau1 = machine.CreateGift("teddy", "Alice");
        cadeau1.Should().Be("🧸 Ourson en peluche pour Alice");

        var cadeau2 = machine.CreateGift("book", "Bob");
        cadeau2.Should().Be("📚 Livre enchanté pour Bob");

        var cadeau3 = machine.CreateGift("robot", "Charlie");
        cadeau3.Should().Be("Échec de la création du cadeau pour Charlie");
    }
}
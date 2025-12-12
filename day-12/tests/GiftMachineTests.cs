using System.Text;
using FluentAssertions;
using GiftMachine.Core;
using GiftMachine.Core.GiftBuilders;
using GiftMachine.Infrastructure;
using GiftMachine.Tests.TestDoubles;
using Xunit;

namespace GiftMachine.Tests;

public class GiftMachineTests
{
    private readonly Core.GiftMachine _machine;

    public GiftMachineTests()
    {
        var timeProvider = new FakeTimeProvider();
        var sledgeDeliveryService = new FakeSledgeDeliveryService();

        var logger = new ConsoleLogger(timeProvider);

        var giftBuilders = new Dictionary<string, IGiftBuilder>(StringComparer.OrdinalIgnoreCase)
        {
            ["teddy"] = new TeddyBuilder(),
            ["car"] = new CarBuilder(),
            ["doll"] = new DollBuilder(),
            ["book"] = new BookBuilder(),
            ["robot"] = new RobotBuilder()
        };
        var giftFactory = new GiftFactory(logger, giftBuilders);

        var giftWrapper = new GiftWrapper(logger);
        var ribbonService = new RibbonService(logger);

        var deliveryService = new DeliveryService(logger, sledgeDeliveryService);
        _machine = new Core.GiftMachine(logger, giftFactory, giftWrapper, ribbonService, deliveryService);
    }

    [Fact]
    public void ExecuteScenario()
    {
        var fakeoutput = new StringBuilder();
        Console.SetOut(new StringWriter(fakeoutput));

        var cadeau1 = _machine.CreateGift("teddy", "Alice");
        cadeau1.Should().Be("🧸 Ourson en peluche pour Alice");

        var cadeau2 = _machine.CreateGift("book", "Bob");
        cadeau2.Should().Be("📚 Livre enchanté pour Bob");

        var cadeau3 = _machine.CreateGift("doll", "Charlotte");
        cadeau3.Should().Be("🪆 Poupée magique pour Charlotte");

        var cadeau4 = _machine.CreateGift("car", "David");
        cadeau4.Should().Be("🚗 Petite voiture pour David");

        var cadeau5 = _machine.CreateGift("robot", "Elisabeth");
        cadeau5.Should().Be("🤖 Robot futuriste pour Elisabeth");

        var output = fakeoutput.ToString();
        output.Should()
            .BeEquivalentTo(
                "[00:00:00] Démarrage de la création du cadeau pour Alice" + Environment.NewLine +
                "[00:00:00] Construction du cadeau de type 'teddy'..." + Environment.NewLine +
                "[00:00:00] Emballage du cadeau : 🧸 Ourson en peluche pour Alice" + Environment.NewLine +
                "[00:00:00] Ajout du ruban magique sur : 🧸 Ourson en peluche pour Alice" + Environment.NewLine +
                "[00:00:00] Livraison en cours vers l'atelier de distribution..." + Environment.NewLine +
                "[00:00:00] Cadeau livré à la zone d’expédition pour Alice" + Environment.NewLine +
                "[00:00:00] Cadeau prêt pour Alice : 🧸 Ourson en peluche pour Alice" + Environment.NewLine +
                "[00:00:00] Démarrage de la création du cadeau pour Bob" + Environment.NewLine +
                "[00:00:00] Construction du cadeau de type 'book'..." + Environment.NewLine +
                "[00:00:00] Emballage du cadeau : 📚 Livre enchanté pour Bob" + Environment.NewLine +
                "[00:00:00] Ajout du ruban magique sur : 📚 Livre enchanté pour Bob" + Environment.NewLine +
                "[00:00:00] Livraison en cours vers l'atelier de distribution..." + Environment.NewLine +
                "[00:00:00] Cadeau livré à la zone d’expédition pour Bob" + Environment.NewLine +
                "[00:00:00] Cadeau prêt pour Bob : 📚 Livre enchanté pour Bob" + Environment.NewLine +
                "[00:00:00] Démarrage de la création du cadeau pour Charlotte" + Environment.NewLine +
                "[00:00:00] Construction du cadeau de type 'doll'..." + Environment.NewLine +
                "[00:00:00] Emballage du cadeau : 🪆 Poupée magique pour Charlotte" + Environment.NewLine +
                "[00:00:00] Ajout du ruban magique sur : 🪆 Poupée magique pour Charlotte" + Environment.NewLine +
                "[00:00:00] Livraison en cours vers l'atelier de distribution..." + Environment.NewLine +
                "[00:00:00] Cadeau livré à la zone d’expédition pour Charlotte" + Environment.NewLine +
                "[00:00:00] Cadeau prêt pour Charlotte : 🪆 Poupée magique pour Charlotte" + Environment.NewLine +
                "[00:00:00] Démarrage de la création du cadeau pour David" + Environment.NewLine +
                "[00:00:00] Construction du cadeau de type 'car'..." + Environment.NewLine +
                "[00:00:00] Emballage du cadeau : 🚗 Petite voiture pour David" + Environment.NewLine +
                "[00:00:00] Ajout du ruban magique sur : 🚗 Petite voiture pour David" + Environment.NewLine +
                "[00:00:00] Livraison en cours vers l'atelier de distribution..." + Environment.NewLine +
                "[00:00:00] Cadeau livré à la zone d’expédition pour David" + Environment.NewLine +
                "[00:00:00] Cadeau prêt pour David : 🚗 Petite voiture pour David" + Environment.NewLine +
                "[00:00:00] Démarrage de la création du cadeau pour Elisabeth" + Environment.NewLine +
                "[00:00:00] Construction du cadeau de type 'robot'..." + Environment.NewLine +
                "[00:00:00] Emballage du cadeau : 🤖 Robot futuriste pour Elisabeth" + Environment.NewLine +
                "[00:00:00] Ajout du ruban magique sur : 🤖 Robot futuriste pour Elisabeth" + Environment.NewLine +
                "[00:00:00] Livraison en cours vers l'atelier de distribution..." + Environment.NewLine +
                "[00:00:00] Cadeau livré à la zone d’expédition pour Elisabeth" + Environment.NewLine +
                "[00:00:00] Cadeau prêt pour Elisabeth : 🤖 Robot futuriste pour Elisabeth" + Environment.NewLine);
    }
}
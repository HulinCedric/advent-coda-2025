using System.Text;
using FluentAssertions;
using Xunit;

namespace GiftMachine.Tests;

public class GiftMachineTests
{
    
 
    [Fact]
    public void GiftMachineShould()
    {
        var fakeoutput = new StringBuilder();
        Console.SetOut(new StringWriter(fakeoutput));

        // var timeProvider = new SystemClockTimeProvider();
        var timeProvider = new FakeTimeProvider();
        var logger = new ConsoleLogger(timeProvider);
        // var sledgeDeliveryService = new RandomSledgeDeliveryService();
        var sledgeDeliveryService = new FakeSledgeDeliveryService();

        var giftBuilders = new Dictionary<string, IGiftBuilder>(StringComparer.OrdinalIgnoreCase)
        {
            ["teddy"] = new TeddyBuilder(),
            ["car"] = new CarBuilder(),
            ["doll"] = new DollBuilder(),
            ["book"] = new BookBuilder(),
        };
        var giftFactory = new GiftFactory(logger, giftBuilders);
        var giftWrapper = new GiftWrapper(logger);
        var ribbonService = new RibbonService(logger);

        var deliveryService = new DeliveryService(logger, sledgeDeliveryService);
        var machine = new GiftMachine(logger, giftFactory, giftWrapper, ribbonService, deliveryService);

        var cadeau1 = machine.CreateGift("teddy", "Alice");
        cadeau1.Should().Be("🧸 Ourson en peluche pour Alice");

        var cadeau2 = machine.CreateGift("book", "Bob");
        cadeau2.Should().Be("📚 Livre enchanté pour Bob");

        var cadeau3 = machine.CreateGift("doll", "Charlotte");
        cadeau3.Should().Be("🪆 Poupée magique pour Charlotte");

        var cadeau4 = machine.CreateGift("car", "David");
        cadeau4.Should().Be("🚗 Petite voiture pour David");

        var cadeau5 = machine.CreateGift("robot", "Elisabeth");
        cadeau5.Should().Be("Échec de la création du cadeau pour Elisabeth");

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
                "[00:00:00] 🚨 ERREUR CRITIQUE 🚨" + Environment.NewLine +
                "[00:00:00] ❌ Type de cadeau 'robot' non reconnu !" + Environment.NewLine +
                "[00:00:00] 🔴 Merci de respecter les principes SOLID" + Environment.NewLine);
    }
}
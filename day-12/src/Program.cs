using GiftMachine.Core;
using GiftMachine.Core.GiftBuilders;
using GiftMachine.Infrastructure;
using GiftMachine.Infrastructure.ExternalSystems;

var logger = new ConsoleLogger(new SystemClockTimeProvider());
var randomService = new RandomSledgeDeliveryService(new RandomFactory());

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
var deliveryService = new DeliveryService(logger, randomService);

var machine = new GiftMachine.Core.GiftMachine(logger, giftFactory, giftWrapper, ribbonService, deliveryService);

var cadeau1 = machine.CreateGift("teddy", "Alice");
Console.WriteLine("🎁 Résultat final : " + cadeau1);
Console.WriteLine("-----------------------------------");

var cadeau2 = machine.CreateGift("book", "Bob");
Console.WriteLine("🎁 Résultat final : " + cadeau2);
Console.WriteLine("-----------------------------------");

var cadeau3 = machine.CreateGift("robot", "Charlie");
Console.WriteLine("🎁 Résultat final : " + cadeau3);
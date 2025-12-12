using GiftMachine;

var logger = new ConsoleLogger(new SystemClockTimeProvider());
var randomService = new RandomSledgeDeliveryService();

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
var deliveryService = new DeliveryService(logger, randomService);

var machine = new GiftMachine.GiftMachine(logger, giftFactory, giftWrapper, ribbonService, deliveryService);

var cadeau1 = machine.CreateGift("teddy", "Alice");
Console.WriteLine("🎁 Résultat final : " + cadeau1);
Console.WriteLine("-----------------------------------");

var cadeau2 = machine.CreateGift("book", "Bob");
Console.WriteLine("🎁 Résultat final : " + cadeau2);
Console.WriteLine("-----------------------------------");

var cadeau3 = machine.CreateGift("robot", "Charlie");
Console.WriteLine("🎁 Résultat final : " + cadeau3);
using GiftMachine;

var logger = new Logger();
var giftFactory = new GiftFactory(logger);
var giftWrapper = new GiftWrapper(logger);
var ribbonService = new RibbonService(logger);
var deliveryService = new DeliveryService(logger);
var machine = new GiftMachine.GiftMachine(logger, giftFactory, giftWrapper, ribbonService, deliveryService);

var cadeau1 = machine.CreateGift("teddy", "Alice");
Console.WriteLine("🎁 Résultat final : " + cadeau1);
Console.WriteLine("-----------------------------------");

var cadeau2 = machine.CreateGift("book", "Bob");
Console.WriteLine("🎁 Résultat final : " + cadeau2);
Console.WriteLine("-----------------------------------");

var cadeau3 = machine.CreateGift("robot", "Charlie");
Console.WriteLine("🎁 Résultat final : " + cadeau3);
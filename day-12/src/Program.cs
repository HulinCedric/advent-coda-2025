using GiftMachine.Core;
using GiftMachine.Core.GiftTypes;
using GiftMachine.Infrastructure;

var logger = new ConsoleLogger(new SystemClockTimeProvider());

var giftFactory = new GiftFactory();
var giftWrapper = new GiftWrapper();
var ribbonService = new RibbonService();
var deliveryService = new DeliveryService(new RandomFactory());

var machine = new GiftMachine.Core.GiftMachine(logger, giftFactory, giftWrapper, ribbonService, deliveryService);

var cadeau1 = machine.CreateGift(GiftType.Teddy, "Alice");
Console.WriteLine("🎁 Résultat final : " + cadeau1);
Console.WriteLine("-----------------------------------");

var cadeau2 = machine.CreateGift(GiftType.Book, "Bob");
Console.WriteLine("🎁 Résultat final : " + cadeau2);
Console.WriteLine("-----------------------------------");

var cadeau3 = machine.CreateGift(GiftType.Robot, "Charlie");
Console.WriteLine("🎁 Résultat final : " + cadeau3);
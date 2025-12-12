var machine = new GiftMachine.GiftMachine();

var cadeau1 = machine.CreateGift("teddy", "Alice");
Console.WriteLine("🎁 Résultat final : " + cadeau1);
Console.WriteLine("-----------------------------------");

var cadeau2 = machine.CreateGift("book", "Bob");
Console.WriteLine("🎁 Résultat final : " + cadeau2);
Console.WriteLine("-----------------------------------");

var cadeau3 = machine.CreateGift("robot", "Charlie");
Console.WriteLine("🎁 Résultat final : " + cadeau3);
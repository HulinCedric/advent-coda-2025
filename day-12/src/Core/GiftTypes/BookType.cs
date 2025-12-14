namespace GiftMachine.Core.GiftTypes;

public sealed record BookType() : GiftType("book")
{
    public override string BuildFor(string recipient) => $"📚 Livre enchanté pour {recipient}";
}
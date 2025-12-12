namespace GiftMachine.Core.GiftBuilders;

public interface IGiftBuilder
{
    string BuildFor(string recipient);
}
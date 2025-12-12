namespace GiftMachine.Infrastructure.ExternalSystems;

public class RandomFactory : IRandomFactory
{
    public Random GetRandom() => new();
}
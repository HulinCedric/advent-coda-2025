using GiftMachine.Core;

namespace GiftMachine.Infrastructure;

public class RandomFactory : IRandomFactory
{
    public Random GetRandom() => new();
}
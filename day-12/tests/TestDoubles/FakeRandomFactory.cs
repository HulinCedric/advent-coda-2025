using GiftMachine.Core;

namespace GiftMachine.Tests.TestDoubles;

public class FakeRandomFactory : IRandomFactory
{
    private int _seed;

    public Random GetRandom() => new(_seed);

    public void WillProvideRandomWithSeed(int seed) => _seed = seed;
}
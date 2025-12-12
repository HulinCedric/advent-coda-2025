using FluentAssertions;
using GiftMachine.Infrastructure;
using Xunit;

namespace GiftMachine.Tests;

public class SystemClockTimeProviderShould
{
    private readonly SystemClockTimeProvider _timeProvider = new();

    [Fact]
    public void DeliverGiftWithSuccess()
        => _timeProvider.GetCurrentDateTime().Should().BeCloseTo(DateTime.Now, TimeSpan.FromSeconds(1));
}
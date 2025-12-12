namespace GiftMachine.Tests;

public class FakeTimeProvider : ITimeProvider
{
    public DateTime GetCurrentDateTime() => new(2025, 12, 24, 00, 00, 00, DateTimeKind.Utc);
}
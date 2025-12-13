using GiftMachine.Core;

namespace GiftMachine.Infrastructure;

public class SystemClockTimeProvider : ITimeProvider
{
    public DateTime GetCurrentDateTime() => DateTime.Now;
}
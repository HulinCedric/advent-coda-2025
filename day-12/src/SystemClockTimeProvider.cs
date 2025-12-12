namespace GiftMachine;

public class SystemClockTimeProvider : ITimeProvider
{
    public DateTime GetCurrentDateTime() => DateTime.Now;
}
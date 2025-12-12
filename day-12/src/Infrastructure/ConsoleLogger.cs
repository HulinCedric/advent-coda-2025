using GiftMachine.Core;

namespace GiftMachine.Infrastructure;

public class ConsoleLogger : ILogger
{
    private readonly ITimeProvider _timeProvider;

    public ConsoleLogger(ITimeProvider timeProvider)
    {
        _timeProvider = timeProvider;
    }

    public void Log(string message)
    {
        var time = _timeProvider.GetCurrentDateTime().ToString("HH:mm:ss");
        Console.WriteLine($"[{time}] {message}");
    }
}
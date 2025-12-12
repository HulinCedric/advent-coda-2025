namespace GiftMachine;

public class ConsoleLogger : ILogger
{
    public void Log(string message)
    {
        string time = DateTime.Now.ToString("HH:mm:ss");
        Console.WriteLine($"[{time}] {message}");
    }
}
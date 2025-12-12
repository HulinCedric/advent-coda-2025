namespace GiftMachine;

public class Logger : ILogger
{
    public void Log(string message)
    {
        string time = DateTime.Now.ToString("HH:mm:ss");
        Console.WriteLine($"[{time}] {message}");
    }
}
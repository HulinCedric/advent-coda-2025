namespace GiftMachine;

public class SystemClockTimeProvider : ITimeProvider
{
    public DateTime GetCurrentDateTime() => DateTime.Now;
}

public class DollBuilder : IGiftBuilder
{
    public string BuildFor(string recipient) => $"🪆 Poupée magique pour {recipient}";
}

public interface IGiftBuilder
{
    string BuildFor(string recipient);
}

public class BookBuilder : IGiftBuilder
{
    public string BuildFor(string recipient) => $"📚 Livre enchanté pour {recipient}";
}

public class CarBuilder : IGiftBuilder
{
    public string BuildFor(string recipient) => $"🚗 Petite voiture pour {recipient}";
}

public class TeddyBuilder : IGiftBuilder
{
    public string BuildFor(string recipient) => $"🧸 Ourson en peluche pour {recipient}";
}
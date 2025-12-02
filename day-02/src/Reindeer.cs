using static Day02.ReindeerStatus;

namespace Day02;

public record Reindeer(string Name, string Presence)
{
    public bool IsPresent() => Presence is Present;
}
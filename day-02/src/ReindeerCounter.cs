namespace Day02;

public static class ReindeerCounter
{
    public static string ReportPresentReindeers(Reindeer[] reindeers)
        => $"🎅 Santa: " +
           $"{CountPresentReindeers(reindeers)} out of {reindeers.Length} reindeers " +
           $"are present in the stable tonight.";

    private static int CountPresentReindeers(Reindeer[] reindeers)
        => reindeers.Count(reindeer => reindeer.IsPresent());
}
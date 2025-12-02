using FluentAssertions;
using Xunit;
using static Day02.ReindeerCounter;

namespace Day02.Tests;

public class PresentReindeerCounterShould
{
    private readonly Reindeer[] _reindeers =
    [
        new("Dasher", "présent"),
        new("Dancer", "vétérinaire"),
        new("Prancer", "présent ? 😬"),
        new("Vixen", "spa"),
        new("Comet", "présent"),
        new("Cupid", "parti"),
        new("Donner", "présent"),
        new("Blitzen", "présent")
    ];

    [Fact]
    public void Count_present_reindeers()
        => ReportPresentReindeers(_reindeers)
            .Should()
            .Be("🎅 Santa: 4 out of 8 reindeers are present in the stable tonight.");
}
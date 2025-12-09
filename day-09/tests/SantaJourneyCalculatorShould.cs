using FluentAssertions;
using Xunit;

namespace Day09.Tests;

public class SantaJourneyCalculatorShould
{
    [Fact]
    public void TODO()
    {
        var lines = File.ReadAllLines("trace");
        lines.Length.Should().Be(500);
        
        lines.First().Should().BeEquivalentTo("146,7714456.11274088,5639226.707649254");
        
        lines.Select(line => line.Split(',')).First().Should().BeEquivalentTo("146", "7714456.11274088", "5639226.707649254");
    }
}
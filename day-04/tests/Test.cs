using FluentAssertions;
using Xunit;
using static Day04.ElvesFileLoader;

namespace Day04.Tests;

public class Test
{
    [Fact]
    public void Get_top3_from_sample()
        => ElvesFrom(fileName: "sample")
            .ComputeReport()
            .Should()
            .Be(
                """
                🍪 Elf of the Day: Nora with 24000 calories!
                🥈 Then comes Marius (11000) and Tika (10000)
                🎁 Combined snack power of Top 3: 45000 calories!
                """);
    
    [Fact]
    public void Get_top3()
        => ElvesFrom(fileName: "data")
            .ComputeReport()
            .Should()
            .Be(
                """
                🍪 Elf of the Day: Susanoo with 57177 calories!
                🥈 Then comes Maeve (52791) and Set (52573)
                🎁 Combined snack power of Top 3: 162541 calories!
                """);
}
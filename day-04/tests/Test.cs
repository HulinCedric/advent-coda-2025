using FluentAssertions;
using Xunit;
using static Day04.ElvesFileLoader;

namespace Day04.Tests;

public class Test
{
    [Fact]
    public void Get_top3()
        => ElvesFrom(fileName: "sample")
            .ComputeReport()
            .Should()
            .Be(
                """
                🍪 Elf of the Day: Nora with 24000 calories!
                🥈 Then comes Marius (11000) and Tika (10000)
                🎁 Combined snack power of Top 3: 45000 calories!
                """);
}
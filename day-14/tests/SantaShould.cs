using FluentAssertions;
using Xunit;

namespace Day14.Tests;

public class SantaShould
{
    [Theory]
    [InlineData("", 1)]
    [InlineData("N", 2)]
    [InlineData("NNESESW", 8)]
    [InlineData("NNSS", 3)]
    public void Count_visited_houses(string instructions, int visitedHousesNumber)
        => Sleigh.Start()
            .FollowInstructions(instructions)
            .VisitedHousesNumber()
            .Should()
            .Be(visitedHousesNumber);

    [Fact]
    public void Count_visited_houses_from_input_instruction()
        => Sleigh.Start()
            .FollowInstructions(File.ReadAllText("steps"))
            .VisitedHousesNumber()
            .Should()
            .Be(5260);
}
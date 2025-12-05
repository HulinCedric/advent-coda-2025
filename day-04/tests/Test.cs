using FluentAssertions;
using Xunit;
using static Day04.ElvesFileLoader;

namespace Day04.Tests;

public class Test
{
    [Fact]
    public void test_read_sample()
        => Elves("sample")
            .Should()
            .BeEquivalentTo(
            [
                new Elf("Pepin", [1000, 2000, 3000]),
                new Elf("Luna", [4000]),
                new Elf("Marius", [5000, 6000]),
                new Elf("Nora", [7000, 8000, 9000]),
                new Elf("Tika", [10000])
            ]);
    
    [Fact]
    public void Get_elf_with_max_calories()
    {
        var elves = Elves("sample");

        var elfOfTheDay = elves.MaxBy(elf => elf.GetTotalCalories());

        elfOfTheDay.Name.Should().Be("Nora");
    }
}
using FluentAssertions;
using Xunit;

namespace Day04.Tests;

public class Test
{
    [Fact]
    public void test_read_sample()
    {
        var elves = LoadElves("sample");

        elves.Should().BeEquivalentTo([new Elf("Pepin", [1000, 2000, 3000])]);
    }

    private static IEnumerable<Elf> LoadElves(string fileName)
    {
        var fileContent = FileContent(fileName);

        fileContent.Should().Contain("Pepin");

        var elvesDescriptions = fileContent.Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries);
        elvesDescriptions.Length.Should().Be(5);

        var elfDescription = elvesDescriptions[0].Split("\r\n");
        elfDescription.Length.Should().Be(4);


        var elf = MapElf(elfDescription);
        
        return [elf];
    }

    private static Elf MapElf(string[] elfDescription)
        => new(elfDescription[0], elfDescription.Skip(1).Select(int.Parse).ToList());

    private static string FileContent(string fileName) => File.ReadAllText(fileName);
}

public record Elf(string Name, List<int> Calories);
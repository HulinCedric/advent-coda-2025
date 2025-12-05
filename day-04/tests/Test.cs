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


        elfDescription[0].Should().Be("Pepin");
        elfDescription[1].Should().Be("1000");
        elfDescription[2].Should().Be("2000");
        elfDescription[3].Should().Be("3000");

        var elf = new Elf(
            elfDescription[0],
            [
                int.Parse(elfDescription[1]),
                int.Parse(elfDescription[2]),
                int.Parse(elfDescription[3])
            ]);
        return [elf];
    }

    private static string FileContent(string fileName) => File.ReadAllText(fileName);
}

public record Elf(string Name, List<int> Calories);
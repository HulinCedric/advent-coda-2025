using FluentAssertions;
using Xunit;

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

    private static IEnumerable<Elf> Elves(string fileName)
        => LoadElvesDescription(fileName)
            .Select(MapElfFromDescription);

    private static IEnumerable<string[]> LoadElvesDescription(string fileName)
    {
        var fileContent = FileContent(fileName);

        var elvesDescriptions = fileContent.Split(
            "\r\n\r\n",
            StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        var d = elvesDescriptions
            .Select(elvesDescription => elvesDescription.Split("\r\n"));
        return d;
    }

    private static Elf MapElfFromDescription(string[] elfDescription)
        => new(elfDescription[0], elfDescription.Skip(1).Select(int.Parse).ToList());

    private static string FileContent(string fileName) => File.ReadAllText(fileName);
}

public record Elf(string Name, List<int> Calories);
using FluentAssertions;
using Xunit;

namespace Day04.Tests;

public class Test
{
    [Fact]
    public void test_read_sample()
    {
        var fileContent = FileContent("sample");

        fileContent.Should().Contain("Pepin");

        var elvesDescriptions = fileContent.Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries);
        elvesDescriptions.Length.Should().Be(5);

        var elfDescription = elvesDescriptions[0].Split("\r\n");
        elfDescription.Length.Should().Be(4);
        
        elfDescription[0].Should().Be("Pepin");
        elfDescription[1].Should().Be("1000");
        elfDescription[2].Should().Be("2000");
        elfDescription[3].Should().Be("3000");
    }

    private static string FileContent(string fileName) => File.ReadAllText(fileName);
}
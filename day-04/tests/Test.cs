using FluentAssertions;
using Xunit;

namespace Day04.Tests;

public class Test
{
    [Fact]
    public void todo()
    {
        var fileContent = FileContent("sample");

        fileContent.Should().Contain("Pepin");
        
        fileContent.Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries)
            .Length.Should()
            .Be(5);
    }

    private static string FileContent(string fileName) => File.ReadAllText(fileName);
}
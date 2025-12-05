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
        
        fileContent.Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries)
            .Length.Should()
            .Be(5);
    }
    
    [Fact]
    public void test_read_data()
    {
        var fileContent = FileContent("data");

        fileContent.Should().Contain("Lugh");
        
        fileContent.Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries)
            .Length.Should()
            .Be(300);
    }

    

    private static string FileContent(string fileName) => File.ReadAllText(fileName);
}
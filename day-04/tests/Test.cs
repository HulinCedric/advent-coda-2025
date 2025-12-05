using FluentAssertions;
using Xunit;

namespace Day04.Tests;

public class Test
{
    [Fact]
    public void todo() => FileContent("sample").Should().Contain("Pepin");

    private static string FileContent(string fileName) => File.ReadAllText(fileName);
}
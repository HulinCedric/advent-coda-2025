using FluentAssertions;
using GifFeedbackAudit.Tests.Verifications;
using Xunit;

namespace GifFeedbackAudit.Tests;

public class AgeShould
{
    [Theory]
    [InlineData("1", 1)]
    [InlineData("9", 9)]
    [InlineData("10", 10)]
    [InlineData("100", 100)]
    [InlineData(" 10", 10)]
    [InlineData("10 ", 10)]
    [InlineData("  10  ", 10)]
    public void Parse_valid_input_return_age(string input, int expected)
        => Age.Parse(input)
            .Should()
            .BeSome(age => age.Value.Should().Be(expected));

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("a")]
    [InlineData("A")]
    [InlineData("%")]
    [InlineData("0")]
    [InlineData("-1")]
    [InlineData("10.5")]
    [InlineData("one")]
    public void Parse_invalid_input_return_none(string? input)
        => Age.Parse(input!)
            .Should()
            .BeNone();
}
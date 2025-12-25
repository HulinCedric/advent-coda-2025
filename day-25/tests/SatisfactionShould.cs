using GifFeedbackAudit.Tests.Verifications;
using Xunit;

namespace GifFeedbackAudit.Tests;

public class SatisfactionShould
{
    [Theory]
    [InlineData("happy")]
    [InlineData("neutral")]
    [InlineData("unhappy")]
    [InlineData("  happy")]
    [InlineData("neutral  ")]
    [InlineData("  unhappy  ")]
    public void Pase_valid_input_return_satisfaction(string input)
        => Satisfaction.Parse(input)
            .Should()
            .BeSome();

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("?")]
    [InlineData("%")]
    [InlineData("1")]
    public void Parse_invalid_input_return_none(string? input)
        => Satisfaction.Parse(input!)
            .Should()
            .BeNone();
}
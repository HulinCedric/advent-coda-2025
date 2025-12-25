using FluentAssertions;
using GifFeedbackAudit.Tests.Verifications;
using Xunit;

namespace GifFeedbackAudit.Tests;

public class FirstNameShould
{
    [Theory]
    [InlineData("Lucie")]
    [InlineData("Antonio")]
    [InlineData("Hiro")]
    [InlineData("Sophie")]
    [InlineData("MarieLouise")]
    [InlineData("OConnor")]
    [InlineData("Cédric")]
    [InlineData("Élise")]
    [InlineData("Ελένη")]
    [InlineData("Алексей")]
    public void Parse_valid_input_return_first_name(string input)
        => FirstName.Parse(input)
            .Should()
            .BeSome();

    [Theory]
    [InlineData("  Antonio", "Antonio")]
    [InlineData("Hiro  ", "Hiro")]
    [InlineData("  Lucie  ", "Lucie")]
    public void Trim_first_name(string input, string expected)
        => FirstName.Parse(input)
            .Should()
            .BeSome()
            .Which.Value.Should()
            .Be(expected);

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("?")]
    [InlineData("%")]
    [InlineData("1")]
    [InlineData("John3")]
    [InlineData("An@")]
    [InlineData("Marie-Louise")]
    [InlineData("O'Connor")]
    public void Parse_invalid_input_return_none(string? input)
        => FirstName.Parse(input!)
            .Should()
            .BeNone();
}
using FluentAssertions;
using GifFeedbackAudit.Tests.Verifications;
using Xunit;

namespace GifFeedbackAudit.Tests;

public class CountryShould
{
    [Theory]
    [InlineData("France")]
    [InlineData("Brazil")]
    [InlineData("Japan")]
    [InlineData("Canada")]
    [InlineData("CôteDivoire")]
    [InlineData("Suisse")]
    public void Parse_valid_input_return_country(string input)
        => Country.Parse(input)
            .Should()
            .BeSome();

    [Theory]
    [InlineData("  Brazil", "Brazil")]
    [InlineData("Japan  ", "Japan")]
    [InlineData("  France  ", "France")]
    public void Trim_country(string input, string expected)
        => Country.Parse(input)
            .Should()
            .BeSome(country => country.Value.Should().Be(expected));

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("?")]
    [InlineData("%")]
    [InlineData("1")]
    [InlineData("U$A")]
    [InlineData("New-Zealand")]
    public void Parse_invalid_input_return_none(string? input)
        => Country.Parse(input!)
            .Should()
            .BeNone();
}
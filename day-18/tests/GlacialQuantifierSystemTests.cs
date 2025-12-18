using FluentAssertions;
using Xunit;

namespace GlacialQuantifierSystem.Tests;

public class GlacialQuantifierSystemTests
{
    [Theory]
    [InlineData('☃', -2)]
    [InlineData('❄', -1)]
    [InlineData('0', 0)]
    [InlineData('*', 1)]
    [InlineData('✦', 2)]
    public void Translate_GQS_symbols(char symbol, int @decimal)
        => Parse(symbol).Should().Be(@decimal);

    private static int Parse(char symbol)
        => symbol switch
        {
            '☃' => -2,
            '❄' => -1,
            '0' => 0,
            '*' => 1,
            '✦' => 2
        };
}
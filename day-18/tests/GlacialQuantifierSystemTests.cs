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
    public void Translate_GQS_symbols(char symbol, int @decimal) => Parse(symbol).Should().Be(@decimal);

    [Theory]
    [InlineData("✦0", 10)]
    [InlineData("*", 1)]
    [InlineData("❄", -1)]
    [InlineData("☃", -2)]
    [InlineData("✦**", 56)]
    [InlineData("✦*0❄", 274)]
    public void Calculate_GQS_operations(string operation, int @decimal) => Calculate(operation).Should().Be(@decimal);

    private static int Calculate(string operation)
        => operation
            .Reverse()
            .Select((symbol, index) => Parse(symbol) * (int)Math.Pow(5, index))
            .Sum();

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
using FluentAssertions;
using Xunit;
using static GlacialQuantifierSystem.Tests.GlacialQuantifierReportReader;

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
    public void Calculate_GQS_measure(string measure, int @decimal) => Calculate(measure).Should().Be(@decimal);

    [Theory]
    [InlineData(new[] { "✦0", "*", "❄", "☃", "✦**" }, 12.8)]
    public void Calculate_GQS_average(string[] measures, double mean) => CalculateAverage(measures).Should().Be(mean);

    [Fact]
    public void Calculate_GQS_average_from_file() => CalculateAverage(ReadReport("gqs")).Should().Be(-288.7762);

    private static double CalculateAverage(IEnumerable<string> measures) => measures.Select(Calculate).Average();

    private static int Calculate(string measure)
        => measure
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
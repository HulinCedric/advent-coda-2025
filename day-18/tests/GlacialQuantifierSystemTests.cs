using FluentAssertions;
using Xunit;
using static GlacialQuantifierSystem.ReportReader;

namespace GlacialQuantifierSystem.Tests;

public class GlacialQuantifierSystemTests
{
    [Theory]
    [InlineData('☃', -2)]
    [InlineData('❄', -1)]
    [InlineData('0', 0)]
    [InlineData('*', 1)]
    [InlineData('✦', 2)]
    public void Translate_GQS_symbols(char symbol, int @decimal) => Symbol.Parse(symbol).Value.Should().Be(@decimal);

    [Theory]
    [InlineData("✦0", 10)]
    [InlineData("*", 1)]
    [InlineData("❄", -1)]
    [InlineData("☃", -2)]
    [InlineData("✦**", 56)]
    [InlineData("✦*0❄", 274)]
    public void Calculate_GQS_measure(string measure, int @decimal)
        => Measure.Parse(measure).Value.Should().Be(@decimal);

    [Theory]
    [InlineData(new[] { "✦0", "*", "❄", "☃", "✦**" }, 12.8)]
    public void Calculate_GQS_average(string[] measures, double average)
        => CalculateAverage(measures.Select(Measure.Parse)).Should().Be(average);

    [Fact]
    public void Calculate_GQS_average_from_file() => CalculateAverage(ReadReport("gqs")).Should().Be(-288.7762);

    private static double CalculateAverage(IEnumerable<Measure> measures) => measures.Average(measure => measure.Value);
}
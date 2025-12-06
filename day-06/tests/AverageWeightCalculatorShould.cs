using FluentAssertions;
using Xunit;
using Xunit.Abstractions;
using static Day06.Tests.WeightCalculator;

namespace Day06.Tests;

public class AverageWeightCalculatorShould(ITestOutputHelper testOutputHelper)
{
    // - {2, 5, 7, 10} -> 6.00 : OK
    // - {2} -> 2.00 : OK
    // - {} -> 0.00 : NOK
    // TODO - {1, 2} -> 1.50
    [Theory]
    [InlineData(new[] { 2, 5, 7, 10 }, 4, 6.00)]
    [InlineData(new[] { 2 }, 1, 2.00)]
    [InlineData(new int[] {}, 0, 0.00)]
    public void Compute_average_weight(int[] weights, int length, double expected)
    {
        var averageWeight = AverageWeight(weights, length);

        testOutputHelper.WriteLine($"Average weight for {length} gifts: {averageWeight:F2}");

        averageWeight.Should().BeApproximately(expected, 0.01);
    }
}

public static class WeightCalculator
{
    public static double AverageWeight(int[] w, int l)
    {
        if (l == 0)
        {
            return 0.0;
        }
        
        var s = 0;
        for (var i = 0; i < l; i++)
        {
            s += w[i];
        }

        return s / l;
    }
}
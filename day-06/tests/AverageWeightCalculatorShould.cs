using FluentAssertions;
using Xunit;
using Xunit.Abstractions;
using static Day06.Tests.WeightCalculator;

namespace Day06.Tests;

public class AverageWeightCalculatorShould(ITestOutputHelper testOutputHelper)
{
    [Theory]
    [ClassData(typeof(AverageWeightScenarios))]
    public void Compute_average_weight(decimal[] weights, int length, decimal expected)
    {
        var averageWeight = AverageWeight(weights, length);

        testOutputHelper.WriteLine($"Average weight for {length} gifts: {averageWeight:F2}");

        averageWeight.Should().BeApproximately(expected, 0.01m);
    }

    private class AverageWeightScenarios : TheoryData<decimal[], int, double>
    {
        public AverageWeightScenarios()
        {
            Add([2m, 5m, 7m, 10m], 4, 6.00);
            Add([2m], 1, 2.00);
            Add([], 0, 0.00);
            Add([1m, 2m], 2, 1.50);
        }
    }
}

public static class WeightCalculator
{
    public static decimal AverageWeight(decimal[] w, int l)
    {
        if (l == 0) return 0.0m;

        decimal s = w.Sum();

        return s / l;
    }
}
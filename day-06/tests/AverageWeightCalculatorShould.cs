using FluentAssertions;
using Xunit;
using Xunit.Abstractions;
using static Day06.Tests.WeightCalculator;

namespace Day06.Tests;

public class AverageWeightCalculatorShould(ITestOutputHelper testOutputHelper)
{
    [Theory]
    [ClassData(typeof(AverageWeightScenarios))]
    public void Compute_average_weight(decimal[] weights,  decimal expected)
    {
        var averageWeight = AverageWeight(weights);

        testOutputHelper.WriteLine($"Average weight for {weights.Length} gifts: {averageWeight:F2}");

        averageWeight.Should().BeApproximately(expected, 0.01m);
    }

    private class AverageWeightScenarios : TheoryData<decimal[], decimal>
    {
        public AverageWeightScenarios()
        {
            Add([2m, 5m, 7m, 10m], 6.00m);
            Add([2m], 2.00m);
            Add([], 0.00m);
            Add([1m, 2m], 1.50m);
        }
    }
}

public static class WeightCalculator
{
    public static decimal AverageWeight(decimal[] weights)
    {
        var numberOfWeights = weights.Length;
        if (numberOfWeights == 0) return 0.0m;

        return weights.Sum() / numberOfWeights;
    }
}
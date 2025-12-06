using FluentAssertions;
using Xunit;
using Xunit.Abstractions;
using static Day06.Tests.WeightCalculator;

namespace Day06.Tests;

public class AverageWeightCalculatorShould(ITestOutputHelper testOutputHelper)
{
    [Theory]
    [ClassData(typeof(AverageWeightScenarios))]
    public void Compute_average_weight(double[] weights, double expected)
    {
        var averageWeight = AverageWeight(weights);

        testOutputHelper.WriteLine($"Average weight for {weights.Length} gifts: {averageWeight:F2}");

        averageWeight.Should().BeApproximately(expected, 0.01);
    }

    private class AverageWeightScenarios : TheoryData<double[], double>
    {
        public AverageWeightScenarios()
        {
            Add([2, 5, 7, 10], 6.00);
            Add([2], 2.00);
            Add([], 0.00);
            Add([1, 2], 1.50);
        }
    }
}

public static class WeightCalculator
{
    public static double AverageWeight(double[] weights)
    {
        var numberOfWeights = weights.Length;
        if (numberOfWeights == 0) return 0.0;

        return weights.Sum() / numberOfWeights;
    }
}
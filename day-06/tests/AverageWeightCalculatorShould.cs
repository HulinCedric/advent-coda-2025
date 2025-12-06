using FluentAssertions;
using Xunit;
using Xunit.Abstractions;
using static Day06.WeightCalculator;

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
}
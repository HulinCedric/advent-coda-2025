using FluentAssertions;
using Xunit;
using static Day06.WeightCalculator;

namespace Day06.Tests;

public class AverageWeightCalculatorShould
{
    [Theory]
    [ClassData(typeof(AverageWeightScenarios))]
    public void Compute_average_weight(double[] weights, double averageWeight)
        => AverageWeight(weights)
            .Should()
            .BeApproximately(averageWeight, 0.01);
}
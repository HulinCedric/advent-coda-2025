using Xunit;

namespace Day06.Tests;

internal class AverageWeightScenarios : TheoryData<double[], double>
{
    public AverageWeightScenarios()
    {
        Add([2, 5, 7, 10], 6.00);
        Add([2], 2.00);
        Add([], 0.00);
        Add([1, 2], 1.50);
    }
}
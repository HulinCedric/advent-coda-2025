using FluentAssertions;
using Xunit;
using Xunit.Abstractions;
using static Day06.Tests.WeightCalculator;

namespace Day06.Tests;

public class Test(ITestOutputHelper testOutputHelper)
{
    [Fact]
    public void Todo()
    {
        int[] weights1 = [2, 5, 7, 10];
        int[] weights2 = [2];

        testOutputHelper.WriteLine("Average weight for 4 gifts: " + AverageWeight(weights1, 4).ToString("F2"));
        testOutputHelper.WriteLine("Average weight for 1 gift: " + AverageWeight(weights2, 1).ToString("F2"));

        false.Should().BeTrue();
    }
}

public static class WeightCalculator
{
    public static double AverageWeight(int[] w, int l)
    {
        var s = 0;
        for (var i = 0; i < l; i++)
        {
            s += w[i];
        }

        return s / l;
    }
}
namespace Day06;

public static class WeightCalculator
{
    public static double AverageWeight(double[] weights)
        => weights.Any()
            ? weights.Average()
            : 0.0;
}
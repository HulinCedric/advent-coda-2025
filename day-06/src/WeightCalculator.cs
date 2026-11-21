namespace Day06;

public static class WeightCalculator
{
    public static double AverageWeight(double[] weights)
        => weights.Length > 0
            ? weights.Average()
            : 0.0;
}
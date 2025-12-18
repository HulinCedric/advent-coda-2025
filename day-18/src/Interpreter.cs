namespace GlacialQuantifierSystem;

public static class Interpreter
{
    public static double CalculateAverage(IEnumerable<Measure> measures) => measures.Average(measure => measure.Value);
}
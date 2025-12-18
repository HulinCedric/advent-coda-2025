namespace GlacialQuantifierSystem;

public static class MeasureExtensions
{
    extension(IEnumerable<Measure> measures)
    {
        public double Average() => measures.Average(measure => measure.Value);
    }
}
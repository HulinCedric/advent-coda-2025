using System.Reflection;
using static System.IO.Path;

namespace GlacialQuantifierSystem;

public static class ReportReader
{
    public static IEnumerable<Measure> ReadReport(string fileName)
        => File.ReadLines(
                Combine(
                    GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
                    fileName))
            .Select(Measure.Parse);
}
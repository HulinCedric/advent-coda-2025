using System.Reflection;
using static System.IO.Path;

namespace GlacialQuantifierSystem.Tests;

public static class GlacialQuantifierReportReader
{
    public static IEnumerable<Measure> ReadReport(string fileName)
        => File.ReadLines(
                Combine(
                    GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
                    fileName))
            .Select(Measure.Parse);
}
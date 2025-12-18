using System.Reflection;
using static System.IO.Path;

namespace GlacialQuantifierSystem.Tests;

public static class FileUtils
{
    public static string GetFileContent(string fileName)
        => File.ReadAllText(
            Combine(
                GetDirectoryName(Assembly.GetExecutingAssembly().Location)!,
                fileName)
        );
}
using ElfLs.Core;
using Spectre.Console;
using Spectre.Console.Rendering;
using static System.Linq.Enumerable;

namespace ElfLs.Presentations;

public class CompactPresentation(IAnsiConsole console) : IPresentationStrategy
{
    public void Present(InventoryDirectory directory) => console.Write(Render(directory));

    private static IRenderable Render(InventoryDirectory directory) => new Text(string.Join(", ", Items(directory)));

    private static IEnumerable<string> Items(InventoryDirectory directory)
        => Empty<string>()
            .Concat(FormatFiles(directory.Files))
            .Concat(FormatDirectories(directory.Directories));

    private static IEnumerable<string> FormatFiles(IEnumerable<InventoryFile> files) => files.Select(FormatFile);

    private static string FormatFile(InventoryFile file)
        => $"{file.Name} ({file.Category}, {file.Weight}, {file.Magic})";

    private static IEnumerable<string> FormatDirectories(IReadOnlyList<InventoryDirectory> directories)
        => directories.Select(FormatDirectory);

    private static string FormatDirectory(InventoryDirectory directory) => $"Dossier {directory.Name}/";
}
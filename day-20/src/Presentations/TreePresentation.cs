using ElfLs.Core;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace ElfLs.Presentations;

public class TreePresentation : IPresentationStrategy
{
    private readonly IAnsiConsole _console;

    public TreePresentation(IAnsiConsole console) => _console = console;

    public void Present(InventoryDirectory directory) => _console.Write(Render(directory));


    private static IRenderable Render(InventoryDirectory directory)
    {
        var tree = new Tree(directory.Name);
        AddDirectoryNodes(tree, directory);
        return tree;
    }

    private static void AddDirectoryNodes(IHasTreeNodes parentNode, InventoryDirectory directory)
    {
        parentNode.AddNodes(FormatFiles(directory.Files));

        foreach (var children in directory.Directories)
        {
            var directoryNode = parentNode.AddNode(FormatDirectory(children));
            AddDirectoryNodes(directoryNode, children);
        }
    }

    private static IEnumerable<string> FormatFiles(IEnumerable<InventoryFile> files) => files.Select(FormatFile);

    private static string FormatFile(InventoryFile file) => $"{file.Name} ({file.Weight}, {file.Magic})";

    private static string FormatDirectory(InventoryDirectory directory) => $"Dossier {directory.Name}/";
}
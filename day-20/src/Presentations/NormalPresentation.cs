using ElfLs.Core;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace ElfLs.Presentations;

public class NormalPresentation : IPresentationStrategy
{
    private readonly IAnsiConsole _console;

    public NormalPresentation(IAnsiConsole console) => _console = console;

    public void Present(InventoryDirectory directory) => _console.Write(Render(directory));

    private static IRenderable Render(InventoryDirectory directory)
    {
        var table = new Table()
            .Border(TableBorder.None)
            .AddColumns(
                new TableColumn("[bold]Nom[/]").PadRight(3),
                new TableColumn("[bold]Type[/]").PadRight(3),
                new TableColumn("[bold]Taille[/]").PadRight(3),
                new TableColumn("[bold]Poids[/]").PadRight(3),
                new TableColumn("[bold]Magie[/]").PadRight(3));

        table.AddEmptyRow();

        foreach (var row in Rows(directory))
        {
            table.AddRow(row);
        }

        return table;
    }

    private static IEnumerable<string[]> Rows(InventoryDirectory directory)
        => Enumerable.Empty<string[]>()
            .Concat(FormatFiles(directory.Files))
            .Concat(FormatDirectories(directory.Directories));

    private static IEnumerable<string[]> FormatFiles(IEnumerable<InventoryFile> files) => files.Select(FormatFile);

    private static string[] FormatFile(InventoryFile file)
        => [file.Name, "Fichier", file.Size, file.Weight, file.Magic];

    private static IEnumerable<string[]> FormatDirectories(IEnumerable<InventoryDirectory> directories)
        => directories.Select(FormatDirectory);

    private static string[] FormatDirectory(InventoryDirectory directory) => [directory.Name, "Dossier", "-", "-", "-"];
}
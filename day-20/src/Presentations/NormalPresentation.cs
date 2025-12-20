using ElfLs.Core;
using Spectre.Console;
using Spectre.Console.Rendering;

namespace ElfLs.Presentations;

public class NormalPresentation : IPresentationStrategy
{
    private readonly IAnsiConsole _console;

    public NormalPresentation(IAnsiConsole console) => _console = console;

    public void Present(InventoryDirectory directory)
    {
        var table = RenderNormal(directory);
        _console.Write(table);
    }

    private static IRenderable RenderNormal(InventoryDirectory directory)
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

        foreach (var f in directory.Files)
        {
            table.AddRow(f.Name, "Fichier", f.Size, f.Weight, f.Magic);
        }

        foreach (var d in directory.Directories)
        {
            table.AddRow(d.Name, "Dossier", "-", "-", "-");
        }

        return table;
    }
}
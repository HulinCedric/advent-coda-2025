using ElfLs.Infrastructure;
using ElfLs.Presentations;
using Spectre.Console;
using Spectre.Console.Cli;

namespace ElfLs;

public class ElfCommand(IAnsiConsole console) : Command<ElfSettings>
{
    public override int Execute(
        CommandContext context,
        ElfSettings settings,
        CancellationToken cancellationToken)
    {
        var directory = new InventoryRepository().Load(settings.Path);
        IPresentationStrategy presentation = settings.DisplayMode switch
        {
            DisplayMode.Normal => new NormalPresentation(console),
            DisplayMode.Compact => new CompactPresentation(console),
            DisplayMode.Tree => new TreePresentation(console),
            _ => new NormalPresentation(console)
        };
        presentation.Present(directory);
        return 0;
    }
}
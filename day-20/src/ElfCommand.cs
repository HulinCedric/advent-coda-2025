using ElfLs.Core;
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
        var presentation = PresentationStrategyFactory(settings.DisplayMode);
        var inventoryRepository = new InventoryRepository();
        var useCase = new TakeInventoryUseCase(inventoryRepository, presentation);

        useCase.Handle(settings.Path);

        return 0;
    }

    private IPresentationStrategy PresentationStrategyFactory(DisplayMode displayMode)
        => displayMode switch
        {
            DisplayMode.Normal => new NormalPresentation(console),
            DisplayMode.Compact => new CompactPresentation(console),
            DisplayMode.Tree => new TreePresentation(console),
            _ => new NormalPresentation(console)
        };
}
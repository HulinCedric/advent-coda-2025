using ElfLs.Core;
using ElfLs.Infrastructure;
using Spectre.Console.Cli;

namespace ElfLs.Commands;

public abstract class ElfCommand : Command<ElfSettings>
{
    private readonly IInventoryRepository _inventoryRepository = new InventoryRepository();

    public override int Execute(
        CommandContext context,
        ElfSettings settings,
        CancellationToken cancellationToken)
    {
        var useCase = new TakeInventoryUseCase(_inventoryRepository, GetPresentation());

        useCase.Handle(settings.Path);

        return 0;
    }

    protected abstract IPresentationStrategy GetPresentation();
}
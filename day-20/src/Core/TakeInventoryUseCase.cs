namespace ElfLs.Core;

public class TakeInventoryUseCase(IInventoryRepository inventoryRepository, IPresentationStrategy presentation)
{
    public void Handle(string directoryPath) => presentation.Present(inventoryRepository.Load(directoryPath));
}
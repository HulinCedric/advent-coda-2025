namespace ElfLs.Core;

public interface IInventoryRepository
{
    InventoryDirectory Load(string directoryPath);
}
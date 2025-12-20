using ElfLs.Core;

namespace ElfLs.Presentations;

public interface IPresentationStrategy
{
    void Present(InventoryDirectory directory);
}
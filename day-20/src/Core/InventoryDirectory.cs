namespace ElfLs.Core;

public sealed record InventoryDirectory
{
    private InventoryDirectory(
        string name,
        IReadOnlyList<InventoryDirectory> directories,
        IReadOnlyList<InventoryFile> files)
    {
        Name = name;
        Directories = directories;
        Files = files;
    }

    public string Name { get; }
    public IReadOnlyList<InventoryDirectory> Directories { get; }
    public IReadOnlyList<InventoryFile> Files { get; }

    public static InventoryDirectory CreateDirectory(
        string name,
        IEnumerable<InventoryDirectory> directories,
        IEnumerable<InventoryFile> files)
        => new(
            name,
            directories.ToList().AsReadOnly(),
            files.ToList().AsReadOnly());
}
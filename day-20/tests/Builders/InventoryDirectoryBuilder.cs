using ElfLs.Core;

namespace ElfLs.Tests.Builders;

public class InventoryDirectoryBuilder
{
    private List<InventoryDirectory> _directories = [];
    private List<InventoryFile> _files = [];
    private string _name = "default-name";

    public static InventoryDirectoryBuilder ADirectory() => new();

    public InventoryDirectoryBuilder Named(string name)
    {
        _name = name;
        return this;
    }

    public InventoryDirectoryBuilder WithDirectories(params IEnumerable<InventoryDirectoryBuilder> builders)
    {
        _directories = builders.Select(builder => builder.Build()).ToList();
        return this;
    }

    public InventoryDirectoryBuilder WithFiles(params IEnumerable<InventoryFileBuilder> builders)
    {
        _files = builders.Select(builder => builder.Build()).ToList();
        return this;
    }

    public InventoryDirectory Build() => InventoryDirectory.CreateDirectory(_name, _directories, _files);

    public static implicit operator InventoryDirectory(InventoryDirectoryBuilder builder) => builder.Build();
}
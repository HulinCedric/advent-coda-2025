using System.Text;
using ElfLs.Core;

namespace ElfLs.Tests.Builders;

public class InventoryFileBuilder
{
    private string _category = string.Empty;
    private string _magic = string.Empty;
    private string _name = "default-name";
    private string _size = string.Empty;
    private string _weight = string.Empty;

    public static InventoryFileBuilder AnItem() => new();

    public InventoryFileBuilder Named(string name)
    {
        _name = name;
        return this;
    }

    public InventoryFileBuilder Categorised(string category)
    {
        _category = category;
        return this;
    }

    public InventoryFileBuilder Sized(string size)
    {
        _size = size;
        return this;
    }

    public InventoryFileBuilder Weighted(string weight)
    {
        _weight = weight;
        return this;
    }

    public InventoryFileBuilder Magic(string magic)
    {
        _magic = magic;
        return this;
    }

    public InventoryFile Build()
        => new(
            Name: _name.Normalize(NormalizationForm.FormC),
            Category: _category.Normalize(NormalizationForm.FormC),
            Size: _size.Normalize(NormalizationForm.FormC),
            Weight: _weight.Normalize(NormalizationForm.FormC),
            Magic: _magic.Normalize(NormalizationForm.FormC));
}
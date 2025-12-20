namespace ElfLs.Infrastructure;

public class InventoryFileMetadata
{
    public static InventoryFileMetadata Empty { get; } = new();
    public string Category { get; init; } = string.Empty;
    public string Size { get; init; } = string.Empty;
    public string Weight { get; init; } = string.Empty;
    public string Magic { get; init; } = string.Empty;
}
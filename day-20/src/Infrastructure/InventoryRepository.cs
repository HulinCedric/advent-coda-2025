using System.Text.Json;
using ElfLs.Core;

namespace ElfLs.Infrastructure;

public sealed class InventoryRepository(string sidecarMetadataSuffix = ".meta.json")
{
    public InventoryDirectory Load(string directoryPath) => ScanDirectory(new DirectoryInfo(directoryPath), ".");

    private InventoryDirectory ScanDirectory(DirectoryInfo directoryInfo, string? directoryName = null)
        => InventoryDirectory.CreateDirectory(
            directoryName ?? directoryInfo.Name,
            ChildrenDirectories(directoryInfo).OrderBy(d => d.Name),
            Files(directoryInfo).OrderBy(f => f.Name));

    private IEnumerable<InventoryDirectory> ChildrenDirectories(DirectoryInfo directoryInfo)
        => directoryInfo
            .EnumerateDirectories()
            .Select(directoryInfo1 => ScanDirectory(directoryInfo1));

    private IEnumerable<InventoryFile> Files(DirectoryInfo directoryInfo)
        => from file in directoryInfo.EnumerateFiles()
            where !IsSidecarFile(file)
            let metadata = LoadMetadata(RelativeSidecarFilePath(file))
            select new InventoryFile(
                Name: file.Name,
                Category: metadata.Category,
                Size: metadata.Size,
                Weight: metadata.Weight,
                Magic: metadata.Magic);

    private string RelativeSidecarFilePath(FileInfo file) => $"{file.FullName}{sidecarMetadataSuffix}";

    private bool IsSidecarFile(FileInfo file)
        => file.FullName.EndsWith(sidecarMetadataSuffix, StringComparison.OrdinalIgnoreCase);

    private static InventoryFileMetadata? LoadMetadata(string filePath)
    {
        if (!File.Exists(filePath)) return InventoryFileMetadata.Empty;

        using var stream = File.OpenRead(filePath);

        var data = JsonSerializer.Deserialize<InventoryFileMetadata>(stream);

        return data ?? InventoryFileMetadata.Empty;
    }
}
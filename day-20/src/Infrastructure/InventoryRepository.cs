using System.Text;
using System.Text.Json;
using ElfLs.Core;

namespace ElfLs.Infrastructure;

public sealed class InventoryRepository(string sidecarMetadataSuffix = ".meta.json")
{
    public InventoryDirectory Load(string directoryPath)
        => ScanDirectory(
            new DirectoryInfo(directoryPath),
            ".".Normalize(NormalizationForm.FormC));

    private InventoryDirectory ScanDirectory(DirectoryInfo directoryInfo, string? directoryName = null)
        => InventoryDirectory.CreateDirectory(
            directoryName ?? directoryInfo.Name.Normalize(NormalizationForm.FormC),
            ChildrenDirectories(directoryInfo).OrderBy(d => d.Name),
            Files(directoryInfo).OrderBy(f => f.Name));

    private IEnumerable<InventoryDirectory> ChildrenDirectories(DirectoryInfo directoryInfo)
        => directoryInfo
            .EnumerateDirectories()
            .Select(info => ScanDirectory(info));

    private IEnumerable<InventoryFile> Files(DirectoryInfo directoryInfo)
        => from file in directoryInfo.EnumerateFiles()
            where !IsSidecarFile(file)
            let metadata = LoadMetadata(RelativeSidecarFilePath(file))
            select new InventoryFile(
                Name: file.Name.Normalize(NormalizationForm.FormC),
                Category: metadata.Category.Normalize(NormalizationForm.FormC),
                Size: metadata.Size.Normalize(NormalizationForm.FormC),
                Weight: metadata.Weight.Normalize(NormalizationForm.FormC),
                Magic: metadata.Magic.Normalize(NormalizationForm.FormC));

    private string RelativeSidecarFilePath(FileInfo file) => $"{file.FullName}{sidecarMetadataSuffix}";

    private bool IsSidecarFile(FileInfo file)
        => file.FullName.EndsWith(sidecarMetadataSuffix, StringComparison.OrdinalIgnoreCase);

    private static InventoryFileMetadata LoadMetadata(string filePath)
    {
        if (!File.Exists(filePath)) return InventoryFileMetadata.Empty;

        using var stream = File.OpenRead(filePath);

        var data = JsonSerializer.Deserialize<InventoryFileMetadata>(stream);

        return data ?? InventoryFileMetadata.Empty;
    }
}
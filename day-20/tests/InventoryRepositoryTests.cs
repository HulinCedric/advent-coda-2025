using ElfLs.Infrastructure;
using FluentAssertions;
using Xunit;

namespace ElfLs.Tests;

public class InventoryRepositoryTests
{
    private readonly InventoryRepository _repository = new(sidecarMetadataSuffix: ".meta.json");

    [Fact]
    public void Load_arborescence_with_metadata_file()
    {
        var directory = _repository.Load("workshop-inventory");

        directory.Should().BeEquivalentTo(Data.SampleData.Directory());
    }
}
using ElfLs.Infrastructure;
using ElfLs.Tests.Data;
using FluentAssertions;
using Xunit;
using static ElfLs.Tests.Utils.InventoryDirectoryFinder;

namespace ElfLs.Tests;

public class InventoryRepositoryTests
{
    private readonly InventoryRepository _repository = new(sidecarMetadataSuffix: ".meta.json");

    [Fact]
    public void Load_arborescence_with_metadata_file()
    {
        var directory = _repository.Load("workshop-inventory".FindDirectory());

        directory.Should().BeEquivalentTo(SampleData.Directory());
    }
}
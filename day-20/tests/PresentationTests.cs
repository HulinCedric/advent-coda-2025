using ElfLs.Presentations;
using ElfLs.Tests.Data;
using FluentAssertions;
using Spectre.Console.Testing;
using Xunit;

namespace ElfLs.Tests;

public class PresentationTests
{
    private readonly TestConsole _console;

    public PresentationTests()
    {
        _console = new TestConsole();
        _console.Profile.Width = 200;
    }

    [Fact]
    public void Present_directory_in_normal_mode()
    {
        // Given
        var directory = SampleData.Directory();

        // When
        new NormalPresentation(_console).Present(directory);

        // Then
        var output = _console.Output.NormalizeLineEndings().TrimLines().Trim();
        output
            .Should()
            .BeEquivalentTo(
                """
                Nom                Type      Taille   Poids   Magie

                Poupée chantante   Fichier   15cm     200g    ✨✨✨
                Livre de sorts     Fichier   20cm     500g    ✨✨
                Boîte à musique    Fichier   10cm     300g    ✨
                Épée en bois       Fichier   50cm     1kg     ✨
                Jouets             Dossier   -        -       -
                """);
    }

    [Fact]
    public void Present_directory_in_compact_mode()
    {
        // Given
        var directory = SampleData.Directory();

        // When
        new CompactPresentation(_console).Present(directory);

        // Then
        var output = _console.Output.NormalizeLineEndings().TrimLines().Trim();
        output
            .Should()
            .BeEquivalentTo(
                """
                Poupée chantante (Jouet, 200g, ✨✨✨), Livre de sorts (Livre, 500g, ✨✨), Boîte à musique (Objet, 300g, ✨), Épée en bois (Arme, 1kg, ✨), Dossier Jouets/
                """);
    }

    [Fact]
    public void Present_directory_in_tree_mode()
    {
        // Given
        var directory = SampleData.Directory();

        // When
        new TreePresentation(_console).Present(directory);

        // Then
        var output = _console.Output.NormalizeLineEndings().TrimLines().Trim();
        output
            .Should()
            .BeEquivalentTo(
                """
                .
                ├── Poupée chantante (200g, ✨✨✨)
                ├── Livre de sorts (500g, ✨✨)
                ├── Boîte à musique (300g, ✨)
                ├── Épée en bois (1kg, ✨)
                └── Dossier Jouets/
                    ├── Sablier magique (300g, ✨✨)
                    └── Boule de neige (100g, ✨)
                """);
    }
}
using System.Text;
using ElfLs.Tests.Utils;
using FluentAssertions;
using Spectre.Console.Cli.Testing;
using Xunit;

namespace ElfLs.Tests;

public class ElfLsTests
{
    private readonly CommandAppTester _app;

    public ElfLsTests()
    {
        _app = new CommandAppTester
        {
            TestSettings = new CommandAppTesterSettings
            {
                TrimConsoleOutput = true
            }
        };
        _app.Configure(AppConfigurationExtensions.Configure);
    }

    [Fact]
    public void Display_help()
    {
        // Given

        // When
        var result = _app.Run("--help");

        // Then
        result.Output
            .Should()
            .BeEquivalentTo(
                """
                USAGE:
                    elf [OPTIONS] <COMMAND>

                OPTIONS:
                    -h, --help    Prints help information

                COMMANDS:
                    normal     Displays items in a detailed table format
                    compact    Displays items in a compact line
                    tree       Displays items in a tree structure
                """);
    }

    [Fact]
    public void Present_directory_in_normal_mode()
    {
        // Given

        // When
        var result = _app.Run("normal", "--path", "workshop-inventory".FindDirectory());

        // Then
        result.Output.Normalize(NormalizationForm.FormC)
            .Should()
            .BeEquivalentTo(
                """
                    Nom                Type      Taille   Poids   Magie

                    Boîte à musique    Fichier   10cm     300g    ✨
                    Épée en bois       Fichier   50cm     1kg     ✨
                    Livre de sorts     Fichier   20cm     500g    ✨✨
                    Poupée chantante   Fichier   15cm     200g    ✨✨✨
                    Jouets             Dossier   -        -       -
                    """.Normalize(NormalizationForm.FormC));
    }

    [Fact]
    public void Present_directory_in_compact_mode()
    {
        // Given

        // When
        var result = _app.Run("compact", "--path", "workshop-inventory".FindDirectory());

        // Then
        result.Output.Normalize(NormalizationForm.FormC)
            .Should()
            .BeEquivalentTo(
                """
                    Boîte à musique (Objet, 300g, ✨), Épée en bois (Arme, 1kg, ✨), Livre de sorts (Livre, 500g, ✨✨), Poupée chantante (Jouet, 200g, ✨✨✨), Dossier Jouets/
                    """.Normalize(NormalizationForm.FormC));
    }

    [Fact]
    public void Present_directory_in_tree_mode()
    {
        // Given

        // When
        var result = _app.Run("tree", "--path", "workshop-inventory".FindDirectory());

        // Then
        result.Output.Normalize(NormalizationForm.FormC)
            .Should()
            .BeEquivalentTo(
                """
                    .
                    ├── Boîte à musique (300g, ✨)
                    ├── Épée en bois (1kg, ✨)
                    ├── Livre de sorts (500g, ✨✨)
                    ├── Poupée chantante (200g, ✨✨✨)
                    └── Dossier Jouets/
                        ├── Boule de neige (100g, ✨)
                        └── Sablier magique (300g, ✨✨)
                    """.Normalize(NormalizationForm.FormC));
    }
}
using ElfLs.Tests.Utils;
using FluentAssertions;
using Spectre.Console.Cli;
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
        _app.SetDefaultCommand<ElfCommand>();
        _app.Configure(config => config.SetApplicationName("elf"));
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
                    elf [OPTIONS]

                OPTIONS:
                                         DEFAULT
                    -h, --help                      Prints help information
                    -p, --path <PATH>    .          Base directory path
                    -n, --normal                    Displays items in a detailed table format
                    -c, --compact                   Displays items in a compact line
                    -t, --tree                      Displays items in a tree structure
                """);
    }

    [Fact]
    public void Present_directory_in_normal_mode()
    {
        // Given

        // When
        var result = _app.Run("--path", "workshop-inventory".FindDirectory(), "--normal");

        // Then
        result.Output
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

        // When
        var result = _app.Run("--path", "workshop-inventory".FindDirectory(), "--compact");

        // Then
        result.Output
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

        // When
        var result = _app.Run("--path", "workshop-inventory".FindDirectory(), "--tree");

        // Then
        result.Output
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
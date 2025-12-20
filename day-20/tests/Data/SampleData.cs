using ElfLs.Core;
using static ElfLs.Tests.Builders.InventoryDirectoryBuilder;
using static ElfLs.Tests.Builders.InventoryFileBuilder;

namespace ElfLs.Tests.Data;

public static class SampleData
{
    public static InventoryDirectory Directory()
        => ADirectory()
            .Named(".")
            .WithFiles(
                AnItem().Named("Poupée chantante").Categorised("Jouet").Sized("15cm").Weighted("200g").Magic("✨✨✨"),
                AnItem().Named("Livre de sorts").Categorised("Livre").Sized("20cm").Weighted("500g").Magic("✨✨"),
                AnItem().Named("Boîte à musique").Categorised("Objet").Sized("10cm").Weighted("300g").Magic("✨"),
                AnItem().Named("Épée en bois").Categorised("Arme").Sized("50cm").Weighted("1kg").Magic("✨"))
            .WithDirectories(ADirectory()
                .Named("Jouets")
                .WithFiles(
                    AnItem().Named("Sablier magique").Categorised("Objet").Sized("15cm").Weighted("300g").Magic("✨✨"),
                    AnItem().Named("Boule de neige").Categorised("Objet").Sized("2cm").Weighted("100g").Magic("✨")));
}
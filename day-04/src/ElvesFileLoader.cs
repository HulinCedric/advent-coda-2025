namespace Day04;

public static class ElvesFileLoader
{
    private static readonly string ElfSeparator = Environment.NewLine + Environment.NewLine;
    private static readonly string ElfCharacteristicSeparator = Environment.NewLine;

    public static IEnumerable<Elf> ElvesFrom(string fileName)
        => LoadElvesDescription(fileName)
            .Select(MapElfFromDescription);

    private static IEnumerable<string[]> LoadElvesDescription(string fileName)
        => ElvesBlock(FileContent(fileName))
            .Select(elf => elf.Split(ElfCharacteristicSeparator));

    private static string FileContent(string fileName) => File.ReadAllText(fileName);

    private static string[] ElvesBlock(string fileContent)
        => fileContent.Split(
            ElfSeparator,
            StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

    private static Elf MapElfFromDescription(string[] elfDescription)
        => new(
            Name: elfDescription[0],
            Calories: elfDescription.Skip(1).Select(int.Parse).ToList());
}
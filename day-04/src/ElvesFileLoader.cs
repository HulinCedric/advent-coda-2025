namespace Day04;

public static class ElvesFileLoader
{
    private const string ElvesSeparator = "\r\n\r\n";
    private const string ElfCharacteristicSeparator = "\r\n";

    public static IEnumerable<Elf> Elves(string fileName)
        => LoadElvesDescription(fileName)
            .Select(MapElfFromDescription);

    private static IEnumerable<string[]> LoadElvesDescription(string fileName)
        => ElvesBlock(FileContent(fileName))
            .Select(elfBlock => elfBlock.Split(ElfCharacteristicSeparator));

    private static string FileContent(string fileName) => File.ReadAllText(fileName);

    private static string[] ElvesBlock(string fileContent)
        => fileContent.Split(
            ElvesSeparator,
            StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

    private static Elf MapElfFromDescription(string[] elfDescription)
        => new(
            Name: elfDescription[0],
            Calories: elfDescription.Skip(1).Select(int.Parse).ToList());
}
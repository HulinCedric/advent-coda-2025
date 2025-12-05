namespace Day04;

public static class ElvesFileLoader
{
    public static IEnumerable<Elf> Elves(string fileName)
        => LoadElvesDescription(fileName)
            .Select(MapElfFromDescription);

    private static IEnumerable<string[]> LoadElvesDescription(string fileName)
    {
        var fileContent = FileContent(fileName);

        const string elvesSeparator = "\r\n\r\n";

        var elvesDescriptions = fileContent.Split(
            elvesSeparator,
            StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        const string elfCharacteristicSeparator = "\r\n";
        return elvesDescriptions
            .Select<string, string[]>(elvesDescription => elvesDescription.Split(elfCharacteristicSeparator));
    }

    private static Elf MapElfFromDescription(string[] elfDescription)
        => new(
            Name: elfDescription[0],
            Calories: elfDescription.Skip(1).Select(int.Parse).ToList());

    private static string FileContent(string fileName) => File.ReadAllText(fileName);
}
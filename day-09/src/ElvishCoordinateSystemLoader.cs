using System.Globalization;

namespace Day09;

public static class ElvishCoordinateSystemLoader
{
    public static IEnumerable<ElvishCoordinate> LoadElvishCoordinates(string fileName)
        => File.ReadAllLines(fileName)
            .Select(ExtractPart)
            .Select(ElvishCoordinate);

    private static string[] ExtractPart(string line) => line.Split(',');

    private static ElvishCoordinate ElvishCoordinate(string[] part)
        => new(
            int.Parse(part[0], CultureInfo.InvariantCulture),
            new Epsg3857Coordinate(
                double.Parse(part[1], CultureInfo.InvariantCulture),
                double.Parse(part[2], CultureInfo.InvariantCulture)));
}
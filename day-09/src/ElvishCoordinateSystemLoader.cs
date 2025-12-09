using System.Globalization;

namespace Day09;

public static class ElvishCoordinateSystemLoader
{
    public static IEnumerable<ElvishCoordinate> LoadElvishCoordinates(string fileName)
    {
        var lines = File.ReadAllLines(fileName);

        return lines.Select(MapElvishCoordinate);
    }

    private static ElvishCoordinate MapElvishCoordinate(string line)
    {
        var part = line.Split(',');
        return new ElvishCoordinate(
            int.Parse(part[0], CultureInfo.InvariantCulture),
            new Epsg3857Coordinate(
                double.Parse(part[1], CultureInfo.InvariantCulture),
                double.Parse(part[2], CultureInfo.InvariantCulture)));
    }
}
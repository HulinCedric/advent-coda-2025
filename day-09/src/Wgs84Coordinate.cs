namespace Day09;

/// <summary>
///     WGS84 Coordinates in degrees
/// </summary>
/// <seealso href="https://en.wikipedia.org/wiki/World_Geodetic_System"/>
public sealed record Wgs84Coordinate(double LongitudeInDegrees, double LatitudeInDegrees);
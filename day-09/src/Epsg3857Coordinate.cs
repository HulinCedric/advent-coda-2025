namespace Day09;

/// <summary>
///     Web Mercator / EPSG:3857 Coordinates in metres
/// </summary>
/// <seealso href="https://en.wikipedia.org/wiki/Web_Mercator_projection"/>
/// <seealso href="https://epsg.io/3857"/>
public sealed record Epsg3857Coordinate(double XInMeter, double YInMeter);
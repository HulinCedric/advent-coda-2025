namespace GlacialQuantifierSystem;

public record Measure(int Value)
{
    public static Measure Parse(string input)
        => new(
            input
                .Reverse()
                .Select((symbol, index) => Symbol.Parse(symbol).Value * (int)Math.Pow(5, index))
                .Sum());
}
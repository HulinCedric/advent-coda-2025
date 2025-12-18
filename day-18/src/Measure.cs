namespace GlacialQuantifierSystem;

public record Measure(double Value)
{
    public static Measure Parse(string input)
        => new(
            input
                .Reverse()
                .Select(Interpret)
                .Sum());

    private static double Interpret(char symbol, int position) => Symbol.Parse(symbol).Value * Math.Pow(5, position);
}
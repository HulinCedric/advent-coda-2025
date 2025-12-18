namespace GlacialQuantifierSystem;

public record Symbol(int Value)
{
    public static Symbol Parse(char input)
        => new(
            input switch
            {
                '☃' => -2,
                '❄' => -1,
                '0' => 0,
                '*' => 1,
                '✦' => 2,
                _ => throw new ArgumentOutOfRangeException(nameof(input), input, null)
            });
}
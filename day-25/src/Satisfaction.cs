using LanguageExt;
using static LanguageExt.Prelude;

namespace GifFeedbackAudit;

public record Satisfaction(string Value)
{
    public static readonly Satisfaction Happy = new("happy");
    public static readonly Satisfaction Neutral = new("neutral");
    public static readonly Satisfaction Unhappy = new("unhappy");

    public static Option<Satisfaction> Parse(string input)
        => Optional(input)
            .Map(s => s.Trim())
            .Bind(ParseSatisfaction);

    private static Option<Satisfaction> ParseSatisfaction(string input)
        => input switch
        {
            "happy" => Happy,
            "neutral" => Neutral,
            "unhappy" => Unhappy,
            _ => None
        };
}
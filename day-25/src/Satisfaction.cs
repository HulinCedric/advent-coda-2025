using LanguageExt;
using static LanguageExt.Prelude;

namespace GifFeedbackAudit;

public record Satisfaction(string Value)
{
    public static Option<Satisfaction> Parse(string input)
        => Optional(input)
            .Map(s => s.Trim())
            .Bind(ParseSatisfaction);

    private static Option<Satisfaction> ParseSatisfaction(string input)
        => input switch
        {
            "happy" => Some(new Satisfaction("happy")),
            "neutral" => Some(new Satisfaction("neutral")),
            "unhappy" => Some(new Satisfaction("unhappy")),
            _ => None
        };

    public bool IsUnhappy() => Value == "unhappy";
}
using LanguageExt;

namespace GifFeedbackAudit;

public record Satisfaction(string Value)
{
    public static Option<Satisfaction> Parse(string input)
    {
        var trimmedInput = input?.Trim();
        return trimmedInput switch
        {
            "happy" => new Satisfaction("happy"),
            "neutral" => new Satisfaction("neutral"),
            "unhappy" => new Satisfaction("unhappy"),
            _ => Option<Satisfaction>.None
        };
    }
}
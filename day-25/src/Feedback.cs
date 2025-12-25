using LanguageExt;
using static LanguageExt.Prelude;

namespace GifFeedbackAudit;

public record Feedback(Country Country, FirstName FirstName, Satisfaction Satisfaction, Age Age)
{
    private const string Separator = "-";

    public static Option<Feedback> Parse(string input)
        => FeedbackParts(input)
            .Bind(Parse);

    private static Option<string[]> FeedbackParts(string input)
        => Optional(input)
            .Map(s => s.Trim())
            .Filter(s => s.Length > 0)
            .Map(s => s.Split(Separator))
            .Filter(parts => parts.Length == 4);

    private static Option<Feedback> Parse(string[] parts)
        => from country in Country.Parse(parts[0])
            from firstName in FirstName.Parse(parts[1])
            from satisfaction in Satisfaction.Parse(parts[2])
            from age in Age.Parse(parts[3])
            select new Feedback(country, firstName, satisfaction, age);
}
using LanguageExt;

namespace GifFeedbackAudit;

public record Feedback(Country Country, FirstName FirstName, Satisfaction Satisfaction, Age Age)
{
    public static Option<Feedback> Parse(string input)
    {
        var feedbackParts = input.Split("-");

        if (feedbackParts.Length != 4)
            return Option<Feedback>.None;


        return from country in Country.Parse(feedbackParts[0])
            from firstName in FirstName.Parse(feedbackParts[1])
            from satisfaction in Satisfaction.Parse(feedbackParts[2])
            from age in Age.Parse(feedbackParts[3])
            select new Feedback(country, firstName, satisfaction, age);
    }
}
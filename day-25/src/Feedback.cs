using LanguageExt;
using LanguageExt.UnsafeValueAccess;

namespace GifFeedbackAudit;

public record Feedback(Country Country, FirstName FirstName, Satisfaction Satisfaction, Age Age)
{
    public static Option<Feedback> Parse(string input)
    {
        var feedbackParts = input.Split("-");

        if (feedbackParts.Length != 4)
            return Option<Feedback>.None;

        var potentialCountry = Country.Parse(feedbackParts[0]);
        if (potentialCountry.IsNone)
            return Option<Feedback>.None;
        var country = potentialCountry.ValueUnsafe()!;

        var potentialFirstName = FirstName.Parse(feedbackParts[1]);
        if (potentialFirstName.IsNone)
            return Option<Feedback>.None;
        var firstName = potentialFirstName.ValueUnsafe()!;

        var potentialSatisfaction = Satisfaction.Parse(feedbackParts[2]);
        if (potentialSatisfaction.IsNone)
            return Option<Feedback>.None;
        var satisfaction = potentialSatisfaction.ValueUnsafe()!;

        var potentialAge = Age.Parse(feedbackParts[3]);
        if (potentialAge.IsNone)
            return Option<Feedback>.None;
        var age = potentialAge.ValueUnsafe()!;
        return new Feedback(country, firstName, satisfaction, age);
    }
}
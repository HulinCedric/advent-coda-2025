using LanguageExt;
using LanguageExt.UnsafeValueAccess;

namespace GifFeedbackAudit;

public record Feedback(Country Country, FirstName FirstName, string Satisfaction, int Age)
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

        var satisfaction = feedbackParts[2];
        var rawAge = feedbackParts[3];
        if (rawAge.Contains("?"))
            return Option<Feedback>.None;
        var age = int.Parse(rawAge);
        return new Feedback(country, firstName, satisfaction, age);
    }
}
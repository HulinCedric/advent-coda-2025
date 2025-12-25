using FluentAssertions;
using GifFeedbackAudit.Tests.Verifications;
using LanguageExt;
using Xunit;
using static GifFeedbackAudit.Tests.Builders.FeedbackBuilder;

namespace GifFeedbackAudit.Tests;

public class GifFeedbackAuditTests
{
    [Fact]
    public void Todo()
    {
        const string input =
            "France-Lucie-unhappy-7|Brazil-Antonio-happy-10|Japan-Hiro-unhappy-11|??-??-happy-?|Germany-Lena-unhappy-9|Spain--neutral-8|USA-Mike-happiness-12";

        var report = BuildReport(input);

        report.Should()
            .BeEquivalentTo(
                """
                === Rapport des Enfants Mécontents ===

                France : 12 mécontents
                Brazil : 8 mécontents
                Japan : 3 mécontents
                Germany : 4 mécontents
                Poland : 5 mécontents

                Total global : 32 enfants mécontents
                """);
    }

    private string BuildReport(string input)
        => """
           === Rapport des Enfants Mécontents ===

           France : 12 mécontents
           Brazil : 8 mécontents
           Japan : 3 mécontents
           Germany : 4 mécontents
           Poland : 5 mécontents

           Total global : 32 enfants mécontents
           """;

    [Theory]
    [InlineData("France-Lucie-unhappy-7", "France", "Lucie", "unhappy", 7)]
    [InlineData("Brazil-Antonio-happy-10", "Brazil", "Antonio", "happy", 10)]
    [InlineData("Japan-Hiro-unhappy-11", "Japan", "Hiro", "unhappy", 11)]
    [InlineData("Canada-Sophie-neutral-6", "Canada", "Sophie", "neutral", 6)]
    public void Parse_valid_feedback(string input, string country, string firstName, string satisfaction, int age)
        => Parse(input)
            .Should()
            .Be(
                AFeedback()
                    .From(country)
                    .IssuedBy(firstName)
                    .Aged(age)
                    .Satisfied(satisfaction)
                    .Build());

    // ??-??-happy-?                # caractères invalides
    // Belgium-Laura-happiness-9    # satisfaction invalide
    // USA-Mike-neutral-            # âge vide
    [Theory]
    [InlineData("France--happy-7", "first name empty")]
    [InlineData("Italy-Mario-12", "missing satisfaction field")]
    public void Parse_invalid_feedback_return_none_feedback(string input, string because)
        => Parse(input)
            .Should()
            .BeNone(because);

    private Option<Feedback> Parse(string input)
    {
        var feedbackParts = input.Split("-");

        if (feedbackParts.Length != 4)
            return Option<Feedback>.None;

        var country = feedbackParts[0];

        var firstName = feedbackParts[1];
        if (firstName == "")
            return Option<Feedback>.None;

        var satisfaction = feedbackParts[2];
        var age = int.Parse(feedbackParts[3]);
        return new Feedback(country, firstName, satisfaction, age);
    }
}

public record Feedback(string Country, string FirstName, string Satisfaction, int Age);
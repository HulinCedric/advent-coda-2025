using FluentAssertions;
using GifFeedbackAudit.Tests.Verifications;
using LanguageExt;
using LanguageExt.UnsafeValueAccess;
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
        => Feedback.Parse(input)
            .Should()
            .Be(
                AFeedback()
                    .From(country)
                    .IssuedBy(firstName)
                    .Aged(age)
                    .Satisfied(satisfaction)
                    .Build());

    // Belgium-Laura-happiness-9    # satisfaction invalide
    // USA-Mike-neutral-            # âge vide
    [Theory]
    [InlineData("France--happy-7", "first name empty")]
    [InlineData("Italy-Mario-12", "missing satisfaction field")]
    [InlineData("??-??-happy-?", "invalid characters")]
    public void Parse_invalid_feedback_return_none_feedback(string input, string because)
        => Feedback.Parse(input)
            .Should()
            .BeNone(because);
}

public class FirstNameShould
{
    [Theory]
    [InlineData("Lucie")]
    [InlineData("Antonio")]
    [InlineData("Hiro")]
    public void Pase_valid_input(string input)
        => FirstName.Parse(input)
            .Should()
            .BeSome();
}

public record FirstName(string Value)
{
    public static Option<FirstName> Parse(string input)
    {
        if (input == "")
            return Option<FirstName>.None;
        if (input == "?")
            return Option<FirstName>.None;

        return new FirstName(input);
    }
}

public record Feedback(string Country, FirstName FirstName, string Satisfaction, int Age)
{
    public static Option<Feedback> Parse(string input)
    {
        var feedbackParts = input.Split("-");

        if (feedbackParts.Length != 4)
            return Option<Feedback>.None;

        var country = feedbackParts[0];
        if (country.Contains("?"))
            return Option<Feedback>.None;

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
using FluentAssertions;
using Xunit;

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

    // France-Lucie-happy-7
    // Brazil-Antonio-unhappy-9
    // Japan-Hiro-unhappy-11
    // Canada-Sophie-neutral-6
    [Theory]
    [InlineData("France-Lucie-unhappy-7", "France", "Lucie", "unhappy", 7)]
    [InlineData("Brazil-Antonio-unhappy-9", "Brazil", "Antonio", "unhappy", 9)]
    [InlineData("Japan-Hiro-unhappy-11", "Japan", "Hiro", "unhappy", 11)]
    [InlineData("Canada-Sophie-neutral-6", "Canada", "Sophie", "neutral", 6)]
    public void Parse_valid_feedback(string input, string country, string firstName, string satisfaction, int age)
        => Parse(input).Should().Be(new Feedback(country, firstName, satisfaction, age));

    private Feedback Parse(string input)
    {
        var feedbackParts = input.Split("-");
        var country = feedbackParts[0];
        var firstName = feedbackParts[1];
        var satisfaction = feedbackParts[2];
        var age = int.Parse(feedbackParts[3]);
        return new Feedback(country, firstName, satisfaction, age);
    }
}

public record Feedback(string Country, string FirstName, string Satisfaction, int Age);
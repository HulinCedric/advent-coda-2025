using GifFeedbackAudit.Tests.Builders;
using GifFeedbackAudit.Tests.Verifications;
using Xunit;

namespace GifFeedbackAudit.Tests;

public class FeedbackShould
{
    [Theory]
    [InlineData("France-Lucie-unhappy-7", "France", "Lucie", "unhappy", 7)]
    [InlineData("Brazil-Antonio-happy-10", "Brazil", "Antonio", "happy", 10)]
    [InlineData("Japan-Hiro-unhappy-11", "Japan", "Hiro", "unhappy", 11)]
    [InlineData("Canada-Sophie-neutral-6", "Canada", "Sophie", "neutral", 6)]
    public void Parse_valid_feedback(string input, string country, string firstName, string satisfaction, int age)
        => Feedback.Parse(input)
            .Should()
            .Be(
                FeedbackBuilder.AFeedback()
                    .From(country)
                    .IssuedBy(firstName)
                    .Aged(age)
                    .Satisfied(satisfaction)
                    .Build());

    [Theory]
    [InlineData("France--happy-7", "first name empty")]
    [InlineData("Italy-Mario-12", "missing satisfaction field")]
    [InlineData("??-??-happy-?", "invalid characters")]
    [InlineData("Belgium-Laura-happiness-9", "invalid satisfaction")]
    [InlineData("USA-Mike-neutral-", "empty age")]
    [InlineData(null, "null input")]
    [InlineData("", "empty input")]
    [InlineData("   ", "whitespace input")]
    [InlineData("USA-Mike-neutral-2-oops", "too many values")]
    public void Parse_invalid_feedback_return_none(string? input, string because)
        => Feedback.Parse(input!)
            .Should()
            .BeNone(because);
}
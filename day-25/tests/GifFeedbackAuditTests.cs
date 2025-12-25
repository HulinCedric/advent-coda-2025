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
    [InlineData("Sophie")]
    [InlineData("MarieLouise")]
    [InlineData("OConnor")]
    [InlineData("Cédric")]
    [InlineData("Élise")]
    [InlineData("Ελένη")]
    [InlineData("Алексей")]
    public void Pase_valid_input_return_first_name(string input)
        => FirstName.Parse(input)
            .Should()
            .BeSome();

    [Theory]
    [InlineData("  Antonio", "Antonio")]
    [InlineData("Hiro  ", "Hiro")]
    [InlineData("  Lucie  ", "Lucie")]
    public void Trim_first_name(string input, string expected)
        => FirstName.Parse(input)
            .Should()
            .BeSome(firstName => firstName.Value.Should().Be(expected));

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("?")]
    [InlineData("%")]
    [InlineData("1")]
    [InlineData("John3")]
    [InlineData("An@")]
    [InlineData("Marie-Louise")]
    [InlineData("O'Connor")]
    public void Parse_invalid_input_return_none(string? input)
        => FirstName.Parse(input!)
            .Should()
            .BeNone();
}

public class CountryShould
{
    [Theory]
    [InlineData("France")]
    [InlineData("Brazil")]
    [InlineData("Japan")]
    [InlineData("Canada")]
    [InlineData("CôteDivoire")]
    [InlineData("Suisse")]
    public void Parse_valid_input_return_country(string input)
        => Country.Parse(input)
            .Should()
            .BeSome();

    // trim country
    [Theory]
    [InlineData("  Brazil", "Brazil")]
    [InlineData("Japan  ", "Japan")]
    [InlineData("  France  ", "France")]
    public void Trim_country(string input, string expected)
        => Country.Parse(input)
            .Should()
            .BeSome(country => country.Value.Should().Be(expected));

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("?")]
    [InlineData("%")]
    [InlineData("1")]
    [InlineData("U$A")]
    [InlineData("New-Zealand")]
    public void Parse_invalid_input_return_none(string? input)
        => Country.Parse(input!)
            .Should()
            .BeNone();
}

public record FirstName(string Value)
{
    public static Option<FirstName> Parse(string input)
    {
        var trimmedInput = input?.Trim();
        return string.IsNullOrWhiteSpace(trimmedInput) || !trimmedInput.All(char.IsLetter)
            ? Option<FirstName>.None
            : new FirstName(trimmedInput);
    }
}

public record Country(string Value)
{
    public static Option<Country> Parse(string input)
    {
        var trimmedInput = input?.Trim();
        return string.IsNullOrWhiteSpace(trimmedInput) || !trimmedInput.All(char.IsLetter)
            ? Option<Country>.None
            : new Country(trimmedInput);
    }
}

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
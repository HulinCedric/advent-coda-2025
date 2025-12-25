using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using LanguageExt;
using Xunit;
using static GifFeedbackAudit.Tests.FeedbackBuilder;

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

    [Theory]
    [InlineData("France--happy-7", "first name empty")]
    public void Parse_invalid_feedback_return_none_feedback(string input, string because)
        => Parse(input)
            .Should()
            .BeNone(because);

    private Option<Feedback> Parse(string input)
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

public class FeedbackBuilder
{
    private int _age = 7;
    private string _country = "France";
    private string _firstName = "Lucie";
    private string _satisfaction = "unhappy";

    public static FeedbackBuilder AFeedback() => new();

    public FeedbackBuilder From(string country)
    {
        _country = country;
        return this;
    }

    public FeedbackBuilder IssuedBy(string firstName)
    {
        _firstName = firstName;
        return this;
    }

    public FeedbackBuilder Satisfied(string satisfaction)
    {
        _satisfaction = satisfaction;
        return this;
    }

    public FeedbackBuilder Aged(int age)
    {
        _age = age;
        return this;
    }

    public Feedback Build() => new(_country, _firstName, _satisfaction, _age);
}

public static class LanguageExtOptionExtensions
{
    public static LanguageExtOptionAssertions<T> Should<T>(this Option<T> instance)
        => new(instance, AssertionChain.GetOrCreate());
}

public class LanguageExtOptionAssertions<T> : ReferenceTypeAssertions<Option<T>, LanguageExtOptionAssertions<T>>
{
    public LanguageExtOptionAssertions(Option<T> instance, AssertionChain chain) : base(instance, chain)
    {
    }

    protected override string Identifier => "option";

    public AndConstraint<LanguageExtOptionAssertions<T>> BeNone(string because = "", params object[] becauseArgs)
    {
        CurrentAssertionChain
            .BecauseOf(because, becauseArgs)
            .WithExpectation(
                "Expected {context:option} to be None{reason}, ",
                because,
                becauseArgs,
                chain => chain
                    .Given(() => Subject)
                    .ForCondition(subject => subject.IsNone)
                    .FailWith("but found to be Some."));

        return new AndConstraint<LanguageExtOptionAssertions<T>>(this);
    }

    public AndWhichConstraint<LanguageExtOptionAssertions<T>, T> BeSome(
        string because = "",
        params object[] becauseArgs)
    {
        CurrentAssertionChain
            .BecauseOf(because, becauseArgs)
            .WithExpectation(
                "Expected {context:option} to be Some{reason}, ",
                because,
                becauseArgs,
                chain => chain
                    .Given(() => Subject)
                    .ForCondition(subject => subject.IsSome)
                    .FailWith("but found to be None."));

        return new AndWhichConstraint<LanguageExtOptionAssertions<T>, T>(this, (T)Subject);
    }

    public AndConstraint<LanguageExtOptionAssertions<T>> BeSome(
        Action<T> action,
        string because = "",
        params object[] becauseArgs)
    {
        BeSome(because, becauseArgs);
        Subject.IfSome(action);

        return new AndConstraint<LanguageExtOptionAssertions<T>>(this);
    }

    public AndConstraint<LanguageExtOptionAssertions<T>> Be(
        T expected,
        string because = "",
        params object[] becauseArgs)
    {
        CurrentAssertionChain
            .BecauseOf(because, becauseArgs)
            .WithExpectation(
                "Expected {context:option} to be Some {0}{reason}, ",
                expected,
                chain => chain
                    .Given(() => Subject)
                    .ForCondition(subject => subject.IsSome)
                    .FailWith("but found to be None.")
                    .Then
                    .ForCondition(subject => subject.Equals(expected))
                    .FailWith("but found Some {0}.", Subject));

        return new AndConstraint<LanguageExtOptionAssertions<T>>(this);
    }
}
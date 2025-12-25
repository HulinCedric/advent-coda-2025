using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using LanguageExt;

namespace GifFeedbackAudit.Tests.Verifications;

public class LanguageExtOptionAssertions<T>(Option<T> instance, AssertionChain chain)
    : ReferenceTypeAssertions<Option<T>, LanguageExtOptionAssertions<T>>(instance, chain)
{
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
using FluentAssertions.Execution;
using LanguageExt;

namespace GifFeedbackAudit.Tests.Verifications;

public static class LanguageExtOptionExtensions
{
    public static LanguageExtOptionAssertions<T> Should<T>(this Option<T> instance)
        => new(instance, AssertionChain.GetOrCreate());
}
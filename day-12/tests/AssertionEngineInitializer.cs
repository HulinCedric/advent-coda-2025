using FluentAssertions;
using FluentAssertions.Extensibility;
using GiftMachine.Tests;

[assembly: AssertionEngineInitializer(
    typeof(AssertionEngineInitializer),
    nameof(AssertionEngineInitializer.AcknowledgeSoftWarning))]

namespace GiftMachine.Tests;

public static class AssertionEngineInitializer
{
    public static void AcknowledgeSoftWarning() => License.Accepted = true;
}
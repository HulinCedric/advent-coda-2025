using FluentAssertions;
using FluentAssertions.Extensibility;
using GiftMachine.Tests.Common;

[assembly: AssertionEngineInitializer(
    typeof(AssertionEngineInitializer),
    nameof(AssertionEngineInitializer.AcknowledgeSoftWarning))]

namespace GiftMachine.Tests.Common;

public static class AssertionEngineInitializer
{
    public static void AcknowledgeSoftWarning() => License.Accepted = true;
}
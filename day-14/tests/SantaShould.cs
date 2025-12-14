using FluentAssertions;
using Xunit;

namespace Day14.Tests;

public class SantaShould
{
    [Fact]
    public void Deliver_to_starting_house() => true.Should().BeFalse();
}
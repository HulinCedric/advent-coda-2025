using FluentAssertions;
using Registry;
using Xunit;

namespace Day07.Tests;

public class GiftRegistryTests
{
    [Fact]
    public void AddGift_WithValidInputs_ShouldAddGiftToRegistry()
    {
        // Arrange
        var registry = new GiftRegistry();

        // Act
        registry.AddGift("Alice", "Doll");

        // Assert
        var gift = registry.FindGiftFor("Alice");
        gift.Should().NotBeNull();
        gift!.ChildName.Should().Be("Alice");
        gift.GiftName.Should().Be("Doll");
    }

    [Fact]
    public void AddGift_WithEmptyChildName_ShouldThrowArgumentException()
    {
        // Arrange
        var registry = new GiftRegistry();

        // Act & Assert
        var act = () => registry.AddGift("", "Toy");
        act.Should().Throw<ArgumentException>()
            .WithParameterName("child");
    }

    [Fact]
    public void AddGift_WithWhitespaceChildName_ShouldThrowArgumentException()
    {
        // Arrange
        var registry = new GiftRegistry();

        // Act & Assert
        var act = () => registry.AddGift("   ", "Toy");
        act.Should().Throw<ArgumentException>()
            .WithParameterName("child");
    }

    [Fact]
    public void AddGift_WithEmptyGiftName_ShouldThrowArgumentException()
    {
        // Arrange
        var registry = new GiftRegistry();

        // Act & Assert
        var act = () => registry.AddGift("Bob", "");
        act.Should().Throw<ArgumentException>()
            .WithParameterName("gift");
    }

    [Fact]
    public void AddGift_WithWhitespaceGiftName_ShouldThrowArgumentException()
    {
        // Arrange
        var registry = new GiftRegistry();

        // Act & Assert
        var act = () => registry.AddGift("Bob", "   ");
        act.Should().Throw<ArgumentException>()
            .WithParameterName("gift");
    }

    [Fact]
    public void AddGift_WithDuplicateChildAndGift_ShouldNotAddDuplicate()
    {
        // Arrange
        var registry = new GiftRegistry();
        registry.AddGift("Charlie", "Train");

        // Act
        registry.AddGift("Charlie", "Train");

        // Assert
        var gift = registry.FindGiftFor("Charlie");
        gift.Should().NotBeNull();
        gift!.GiftName.Should().Be("Train");
    }

    [Fact]
    public void AddGift_WithPackedParameter_ShouldSetIsPackedProperty()
    {
        // Arrange
        var registry = new GiftRegistry();

        // Act
        registry.AddGift("David", "Book", packed: true);

        // Assert
        var gift = registry.FindGiftFor("David");
        gift.Should().NotBeNull();
        gift!.IsPacked.Should().BeTrue();
    }

    [Fact]
    public void AddGift_WithoutPackedParameter_ShouldSetIsPackedToNull()
    {
        // Arrange
        var registry = new GiftRegistry();

        // Act
        registry.AddGift("Emma", "Puzzle");

        // Assert
        var gift = registry.FindGiftFor("Emma");
        gift.Should().NotBeNull();
        gift!.IsPacked.Should().BeNull();
    }

    [Fact]
    public void MarkPacked_WithExistingChild_ShouldSetIsPackedToTrueAndReturnTrue()
    {
        // Arrange
        var registry = new GiftRegistry();
        registry.AddGift("Frank", "Ball");

        // Act
        var result = registry.MarkPacked("Frank");

        // Assert
        result.Should().BeTrue();
        var gift = registry.FindGiftFor("Frank");
        gift!.IsPacked.Should().BeTrue();
    }

    [Fact]
    public void MarkPacked_WithNonExistingChild_ShouldReturnFalse()
    {
        // Arrange
        var registry = new GiftRegistry();

        // Act
        var result = registry.MarkPacked("NonExistent");

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void FindGiftFor_WithExistingChild_ShouldReturnGift()
    {
        // Arrange
        var registry = new GiftRegistry();
        registry.AddGift("Grace", "Teddy Bear");

        // Act
        var gift = registry.FindGiftFor("Grace");

        // Assert
        gift.Should().NotBeNull();
        gift!.ChildName.Should().Be("Grace");
        gift.GiftName.Should().Be("Teddy Bear");
    }

    [Fact]
    public void FindGiftFor_WithNonExistingChild_ShouldReturnNull()
    {
        // Arrange
        var registry = new GiftRegistry();

        // Act
        var gift = registry.FindGiftFor("NonExistent");

        // Assert
        gift.Should().BeNull();
    }

    [Fact]
    public void ComputeElfScore_WithEmptyRegistry_ShouldReturnZero()
    {
        // Arrange
        var registry = new GiftRegistry();

        // Act
        var score = registry.ComputeElfScore();

        // Assert
        score.Should().Be(0);
    }

    [Fact]
    public void ComputeElfScore_WithOnePackedGift_ShouldReturnCorrectScore()
    {
        // Arrange
        var registry = new GiftRegistry();
        registry.AddGift("Henry", "Car", packed: true);

        // Act
        var score = registry.ComputeElfScore();

        // Assert - BaseElfScore (42) + packed (7) + notes (1)
        score.Should().Be(50);
    }

    [Fact]
    public void ComputeElfScore_WithOneUnpackedGift_ShouldReturnCorrectScore()
    {
        // Arrange
        var registry = new GiftRegistry();
        registry.AddGift("Ivy", "Blocks", packed: false);

        // Act
        var score = registry.ComputeElfScore();

        // Assert - BaseElfScore (42) + unpacked (3) + notes (1)
        score.Should().Be(46);
    }

    [Fact]
    public void ComputeElfScore_WithOneUnspecifiedPackingGift_ShouldReturnCorrectScore()
    {
        // Arrange
        var registry = new GiftRegistry();
        registry.AddGift("Jack", "Rocket");

        // Act
        var score = registry.ComputeElfScore();

        // Assert - BaseElfScore (42) + unspecified/null packing (3) + notes (1)
        score.Should().Be(46);
    }

    [Fact]
    public void ComputeElfScore_WithMultipleGifts_ShouldReturnSumOfScores()
    {
        // Arrange
        var registry = new GiftRegistry();
        registry.AddGift("Karen", "Bike", packed: true);  // 42 + 7 + 1 = 50
        registry.AddGift("Leo", "Robot", packed: false);  // 42 + 3 + 1 = 46
        registry.AddGift("Maya", "Drum");                  // 42 + 3 + 1 = 46

        // Act
        var score = registry.ComputeElfScore();

        // Assert
        score.Should().Be(142); // 50 + 46 + 46
    }

    [Fact]
    public void GiftRegistry_WithInitialGifts_ShouldPopulateRegistry()
    {
        // Arrange
        const int baseElfScore = 42;
        const int packedPoints = 7;
        const int unpackedPoints = 3;
        const int notesPoints = 1;
        
        var initialGifts = new List<Gift>
        {
            new() { ChildName = "Nora", GiftName = "Piano", IsPacked = true, Notes = "Fragile" },
            new() { ChildName = "Oscar", GiftName = "Guitar", IsPacked = false, Notes = "Express" }
        };

        // Act
        var registry = new GiftRegistry(initialGifts);

        // Assert
        registry.FindGiftFor("Nora").Should().NotBeNull();
        registry.FindGiftFor("Oscar").Should().NotBeNull();
        var expectedScore = (baseElfScore + packedPoints + notesPoints) + (baseElfScore + unpackedPoints + notesPoints);
        registry.ComputeElfScore().Should().Be(expectedScore);
    }

    [Fact]
    public void GiftRegistry_WithNullInitialGifts_ShouldCreateEmptyRegistry()
    {
        // Arrange & Act
        var registry = new GiftRegistry(null);

        // Assert
        registry.ComputeElfScore().Should().Be(0);
    }

    [Fact]
    public void Gift_Properties_ShouldBeSettable()
    {
        // Arrange & Act
        var gift = new Gift
        {
            ChildName = "Paul",
            GiftName = "Scooter",
            IsPacked = true,
            Notes = "Handle with care"
        };

        // Assert
        gift.ChildName.Should().Be("Paul");
        gift.GiftName.Should().Be("Scooter");
        gift.IsPacked.Should().BeTrue();
        gift.Notes.Should().Be("Handle with care");
    }

    [Fact]
    public void Gift_IsPacked_ShouldBeMutable()
    {
        // Arrange
        var gift = new Gift
        {
            ChildName = "Quinn",
            GiftName = "Skateboard",
            IsPacked = false,
            Notes = "ok"
        };

        // Act
        gift.IsPacked = true;

        // Assert
        gift.IsPacked.Should().BeTrue();
    }
}

namespace Day04;

public record Elf(string Name, IReadOnlyList<int> Calories)
{
    public int GetTotalCalories() => Calories.Sum();
}
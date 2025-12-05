namespace Day04;

public record Elf(string Name, List<int> Calories)
{
    public int GetTotalCalories() => Calories.Sum();
}
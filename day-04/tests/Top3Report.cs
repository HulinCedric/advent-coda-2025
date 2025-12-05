namespace Day04.Tests;

public static class Top3Report
{
    public static string ComputeReport(this IEnumerable<Elf> elves)
    {
        var top3 = elves
            .OrderByDescending(elf => elf.GetTotalCalories())
            .Take(3)
            .ToList();

        var firstElf = top3[0];
        var secondElf = top3[1];
        var thirdElf = top3[2];

        return $"""
                🍪 Elf of the Day: {firstElf.Name} with {firstElf.GetTotalCalories()} calories!
                🥈 Then comes {secondElf.Name} ({secondElf.GetTotalCalories()}) and {thirdElf.Name} ({thirdElf.GetTotalCalories()})
                🎁 Combined snack power of Top 3: {top3.Sum(elf => elf.GetTotalCalories())} calories!
                """;
    }
}
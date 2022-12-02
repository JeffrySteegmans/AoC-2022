using AoC.Domain;
using System.Reflection;

namespace AoC.PuzzleCli.Days;

internal class Day01 : IDay
{
    private readonly string _executionPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;

    public async Task Execute()
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine($"Executing day 1{Environment.NewLine}");
        Console.ForegroundColor = ConsoleColor.White;

        var input = await File.ReadAllTextAsync($@"{_executionPath}\Input\Day01.txt");

        var expedition = new Expedition();
        expedition.AddElvesByMeals(input);

        ExecutePart01(expedition);
    }

    private void ExecutePart01(Expedition expedition)
    {
        Console.WriteLine($"Solution Part 01: {expedition.GetMaxCalorieCount()}");
    }
}

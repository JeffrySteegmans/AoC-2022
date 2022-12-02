using AoC.Domain;
using System.Reflection;

namespace AoC.PuzzleCli.Days;

public class Day02 : IDay
{
    private readonly string _executionPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;

    public async Task Execute()
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine($"Executing day 2{Environment.NewLine}");
        Console.ForegroundColor = ConsoleColor.White;

        var input = await File.ReadAllTextAsync($@"{_executionPath}\Input\Day02.txt");

        var rockPaperScissorsGame = new RockPaperScissorsGame(input);

        ExecutePart01(rockPaperScissorsGame);
    }

    public void ExecutePart01(RockPaperScissorsGame rockPaperScissorsGame)
    {
        Console.WriteLine($"Solution Part 01: {rockPaperScissorsGame.CalculateTotalScore()}");
    }
}

namespace AoC.PuzzleCli.Days;

internal class Day03 : IDay
{
    private readonly string _executionPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;

    public async Task Execute()
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine($"Executing day 3{Environment.NewLine}");
        Console.ForegroundColor = ConsoleColor.White;

        var input = await File.ReadAllTextAsync($@"{_executionPath}\Input\Day03.txt");

        var expedition = new Expedition();
        expedition.AddElvesByListOfRuckSacks(input);

        ExecutePart01(expedition);
        ExecutePart02(expedition);
    }

    private static void ExecutePart01(Expedition expedition)
    {
        Console.WriteLine($"Solution Part 01: {expedition.CalculateSumOfPriorityOfMisplacedItems()}");
    }

    private static void ExecutePart02(Expedition expedition)
    {
        Console.WriteLine($"Solution Part 02: ");
    }
}

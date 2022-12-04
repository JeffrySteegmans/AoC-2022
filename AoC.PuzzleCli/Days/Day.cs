namespace AoC.PuzzleCli.Days;

public abstract class Day : IDay
{
    private readonly string _day;
    private readonly string _executionPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
    protected string _input = string.Empty;


    public Day(string day)
    {
        _day = day;
    }

    public async Task Execute()
    {
        _input = await File.ReadAllTextAsync($@"{_executionPath}\Input\Day{_day}.txt");

        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine($"Executing day {_day}{Environment.NewLine}");
        Console.ForegroundColor = ConsoleColor.White;

        var results = CalculateResults();

        PrintResults(results);
    }

    private void PrintResults(CalculationResults results)
    {
        Console.WriteLine($"Solution Part 01: {results.ResultPart1}");
        Console.WriteLine($"Solution Part 02: {results.ResultPart2}");
    }

    public abstract CalculationResults CalculateResults();
}

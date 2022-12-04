using AoC.PuzzleCli;

Console.Title = "Advent of Code 2022";

do
{
    Console.Clear();
    Console.Write("Which day? (1-24 or 0 for all days): ");
    var input = Console.ReadLine()!;
    Console.Clear();

    if (input == "0")
    {
        foreach (var dayNumber in Enumerable.Range(1, 24))
        {
            var day = DayFactory.Create(dayNumber);
            await day.Execute();
        }
    }
    else
    {
        var dayNumber = string.IsNullOrWhiteSpace(input) ? 1 : int.Parse(input);

        var day = DayFactory.Create(dayNumber);
        await day.Execute();
    }

    Console.WriteLine($"{Environment.NewLine}-------------------------------{Environment.NewLine}Execution done");

    Console.Write($"{Environment.NewLine}Press q to quit or anykey to retry: ");
} while (Console.ReadKey().Key != ConsoleKey.Q);
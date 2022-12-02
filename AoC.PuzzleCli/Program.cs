using AoC.PuzzleCli;

Console.Title = "Advent of Code 2022";

do
{
    Console.Clear();
    Console.Write("Which day? (1-24): ");
    var input = Console.ReadLine()!;
    var dayNumber = string.IsNullOrWhiteSpace(input) ? 1 : int.Parse(input);

    Console.Clear();
    var day = DayFactory.Create(dayNumber);
    await day.Execute();

    Console.WriteLine($"{Environment.NewLine}-------------------------------{Environment.NewLine}Execution done");

    Console.Write($"{Environment.NewLine}Press q to quit or anykey to retry: ");
} while (Console.ReadKey().Key != ConsoleKey.Q);
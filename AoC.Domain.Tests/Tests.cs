namespace AoC.Domain.Tests;

public abstract class Tests
{
    private readonly string _executionPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;

    protected async Task<string> GetInputForDay(int dayNumber)
    {
        return await File.ReadAllTextAsync($"{_executionPath}/Input/Day{dayNumber.ToString().PadLeft(2, '0')}.txt");
    }
}

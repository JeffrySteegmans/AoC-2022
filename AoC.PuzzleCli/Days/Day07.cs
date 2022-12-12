using AoC.Domain.HandheldDevice;

namespace AoC.PuzzleCli.Days;

public class Day07 : Day
{
    public Day07() : base("07")
    {
    }

    public override CalculationResults CalculateResults()
    {
        var maxSize = 100000;
        var requiredSpace = 30000000;
        var fileSystem = new FileSystem();
        fileSystem.ApplyTerminalOutput(_input);

        var resultPart1 = fileSystem.GetSumOfFoldersWithMaxSize(maxSize);
        var resultPart2 = fileSystem.GetSizeOfSmallestDirectoryToDelete(requiredSpace);

        return new CalculationResults(resultPart1.ToString(), resultPart2.ToString());
    }
}

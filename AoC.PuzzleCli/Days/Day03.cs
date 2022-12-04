namespace AoC.PuzzleCli.Days;

internal class Day03 : Day
{
    private readonly string _executionPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;

    public Day03() : base("03")
    {
    }

    public override CalculationResults CalculateResults()
    {
        var expedition = new Expedition();
        expedition.AddElvesByListOfRuckSacks(_input);

        return new CalculationResults(
            expedition.CalculateSumOfPriorityOfMisplacedItems().ToString(),
            expedition.CalculateSumOfBadgePriority().ToString()
        );
    }
}

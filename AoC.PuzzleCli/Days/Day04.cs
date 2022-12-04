namespace AoC.PuzzleCli.Days;

public class Day04 : Day
{
    private readonly string _executionPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;

    public Day04() : base("04")
    {
    }

    public override CalculationResults CalculateResults()
    {
        var expedition = new Expedition();
        expedition.AddElvesBySectionAssignmentPairs(_input);

        return new CalculationResults(
            expedition.NumberOfFullyContainingAssignments.ToString(),
            expedition.NumberOfOverlappingPairs.ToString()
        );
    }
}

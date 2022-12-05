using AoC.Domain.Crane;

namespace AoC.PuzzleCli.Days;

public class Day05 : Day
{
    public Day05() : base("05")
    {
    }

    public override CalculationResults CalculateResults()
    {
        var expedition = new Expedition();
        expedition.AddShipByStartingStacksAndRearrangmentProcedure(_input, CraneVersion.V9000);

        var resultPart1 = expedition.GetTopCrates();

        expedition = new Expedition();
        expedition.AddShipByStartingStacksAndRearrangmentProcedure(_input, CraneVersion.V9001);

        var resultPart2 = expedition.GetTopCrates();

        return new CalculationResults(resultPart1, resultPart2);
    }
}

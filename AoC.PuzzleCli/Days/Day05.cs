namespace AoC.PuzzleCli.Days;

public class Day05 : Day
{
    public Day05() : base("05")
    {
    }

    public override CalculationResults CalculateResults()
    {
        var expedition = new Expedition();

        expedition.AddShipByStartingStacksAndRearrangmentProcedure(_input);

        var resultPart1 = string.Join("", expedition.Ship.GetTopCrates().Select(x => x.Marking));

        return new CalculationResults(resultPart1, "");
    }
}

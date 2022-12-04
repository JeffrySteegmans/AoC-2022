namespace AoC.PuzzleCli.Days;

internal class Day01 : Day
{
    public Day01() : base("01")
    {
    }

    public override CalculationResults CalculateResults()
    {
        var expedition = new Expedition();
        expedition.AddElvesByMeals(_input);

        return new CalculationResults(
            expedition.GetMaxCalorieCount().ToString(),
            expedition.GetSumOfTopThreeCalorieCount().ToString()
        );
    }
}

namespace AoC.PuzzleCli.Days;

public class Day02 : Day
{
    private readonly string _executionPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;

    public Day02() : base("02")
    {
    }

    public override CalculationResults CalculateResults()
    {
        var rockPaperScissorsGame = new RockPaperScissorsGame(_input);

        return new CalculationResults(
            rockPaperScissorsGame.CalculateTotalScore().ToString(),
            rockPaperScissorsGame.CalculateTotalScore(Domain.Version.V2).ToString()
        );
    }
}

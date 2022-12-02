namespace AoC.Domain;

public class RockPaperScissorsGame
{
    const int ScoreRock = 1;
    const int ScorePaper = 2;
    const int ScoreScissors = 3;
    private readonly string _encryptedStrategyGuide;

    public RockPaperScissorsGame(string encryptedStrategyGuide)
    {
        _encryptedStrategyGuide = encryptedStrategyGuide;
    }

    public int CalculateTotalScore()
    {
        var rounds = _encryptedStrategyGuide.Split(Environment.NewLine);
        var totalScore = 0;

        foreach (var round in rounds)
        {
            totalScore += CalculateRoundScore(round);
        }

        return totalScore;
    }

    private int CalculateRoundScore(string round)
    {
        var responses = round.Split(" ");

        var responseScore = responses[1] switch
        {
            "X" => ScoreRock,
            "Y" => ScorePaper,
            "Z" => ScoreScissors,
            _ => throw new ArgumentException($"{responses[1]} is not a valid response")
        };

        var outcomeScore = responses switch
        {
            ["A", "Y"] or ["B", "Z"] or ["C", "X"] => 6,
            ["A", "X"] or ["B", "Y"] or ["C", "Z"] => 3,
            _ => 0
        }; ;

        return responseScore + outcomeScore;
    }
}

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

    public int CalculateTotalScore(Version version = Version.V1)
    {
        var rounds = _encryptedStrategyGuide.Split(Environment.NewLine);
        var totalScore = 0;

        foreach (var round in rounds)
        {
            totalScore += version switch
            {
                Version.V1 => CalculateRoundScore(round),
                Version.V2 => CalculateRoundScoreV2(round),
                _ => throw new ArgumentException($"{version} is not a valid version")
            };
        }

        return totalScore;
    }

    private int CalculateRoundScore(string round)
    {
        var strategy = round.Split(" ");

        var responseScore = CalculateResponseScore(strategy[1]);

        var outcomeScore = strategy switch
        {
            ["A", "Y"] or ["B", "Z"] or ["C", "X"] => 6,
            ["A", "X"] or ["B", "Y"] or ["C", "Z"] => 3,
            _ => 0
        };

        return responseScore + outcomeScore;
    }

    private int CalculateRoundScoreV2(string round)
    {
        var strategy = round.Split(" ");

        var response = CalculateResponse(strategy);
        var responseScore = CalculateResponseScoreV2(response);

        var outcomeScore = (strategy[0], response) switch
        {
            ("A", "B") or ("B", "C") or ("C", "A") => 6,
            ("A", "A") or ("B", "B") or ("C", "C") => 3,
            _ => 0
        };


        return responseScore + outcomeScore;
    }

    private int CalculateResponseScore(string response) => response switch
    {
        "X" => ScoreRock,
        "Y" => ScorePaper,
        "Z" => ScoreScissors,
        _ => throw new ArgumentException($"{response} is not a valid response")
    };

    private int CalculateResponseScoreV2(string response) => response switch
    {
        "A" => ScoreRock,
        "B" => ScorePaper,
        "C" => ScoreScissors,
        _ => throw new ArgumentException($"{response} is not a valid response")
    };

    private string CalculateResponse(string[] strategy)
    {
        return strategy switch
        {
            ["A", "X"] => "C",
            ["A", "Y"] => "A",
            ["A", "Z"] => "B",
            ["B", "X"] => "A",
            ["B", "Y"] => "B",
            ["B", "Z"] => "C",
            ["C", "X"] => "B",
            ["C", "Y"] => "C",
            ["C", "Z"] => "A",
            _ => throw new ArgumentException($"[{strategy[0]}, {strategy[1]}] is not a valid strategy")
        };
    }
}

public enum Version
{
    V1,
    V2
}

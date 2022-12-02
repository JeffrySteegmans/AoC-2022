namespace AoC.Domain.Tests;

public class RockPaperScissorsGameTests
{
    [Fact]
    public void GivenEncryptedStrategyGuide_WhenCalculateTotalScore_ShouldCalculateCorrectScore()
    {
        var expectedTotalScore = 15;
        var encryptedStrategyGuid = "A Y\r\nB X\r\nC Z";
        var sut = new RockPaperScissorsGame(encryptedStrategyGuid);

        var totalScore = sut.CalculateTotalScore();

        totalScore.Should().Be(expectedTotalScore);
    }
}

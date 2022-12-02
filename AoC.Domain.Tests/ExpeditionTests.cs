namespace AoC.Domain.Tests;

public class ExpeditionTests
{
    private readonly string _executionPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;

    [Fact]
    public async Task GivenInputTextFile_WhenCreateElvesByMeals_ThenShouldHaveCreatedCorrectAmountOfElves()
    {
        var expectedElvesCount = 5;
        var input = await GetInputForDay01();
        var sut = new Expedition();

        sut.AddElvesByMeals(input);

        sut.Elves.Count.Should().Be(expectedElvesCount);
    }

    [Fact]
    public async Task GivenInputTextFile_WhenGetMaxCalorieCount_ThenShouldReturnCorrectAmount()
    {
        var expectedCaloryCount = 24000;
        var input = await GetInputForDay01();
        var sut = new Expedition();

        sut.AddElvesByMeals(input);

        sut.GetMaxCalorieCount().Should().Be(expectedCaloryCount);
    }

    private async Task<string> GetInputForDay01()
    {
        return await File.ReadAllTextAsync($"{_executionPath}/Input/Day01.txt");
    }
}

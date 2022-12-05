using AoC.Domain.Tests.Builders;

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
        var expectedCalorieCount = 24000;
        var input = await GetInputForDay01();
        var sut = new Expedition();

        sut.AddElvesByMeals(input);

        sut.GetMaxCalorieCount().Should().Be(expectedCalorieCount);
    }

    [Fact]
    public async Task GivenInputTextFile_WhenGetSumOfTopThreeCalorieCount_ThenShouldReturnCorrectAmount()
    {
        var expectedCalorieCount = 45000;
        var input = await GetInputForDay01();
        var sut = new Expedition();

        sut.AddElvesByMeals(input);

        sut.GetSumOfTopThreeCalorieCount().Should().Be(expectedCalorieCount);
    }

    [Fact]
    public async Task GivenListOfRuckSacks_WhenCalculateSumOfPriorityOfMisplacedItems_ThenPriorityShouldBeCalculatedCorrectly()
    {
        var expectedPriority = 157;
        var input = await GetInputForDay03();

        var expedition = new Expedition();
        expedition.AddElvesByListOfRuckSacks(input);

        expedition.CalculateSumOfPriorityOfMisplacedItems().Should().Be(expectedPriority);
    }

    [Theory]
    [InlineData("vJrwpWtwJgWrhcsFMMfFFhFp\r\njqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL\r\nPmmdzqPrVvPwwTWBwg", 'r')]
    [InlineData("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn\r\nttgJtRGJQctTZtZT\r\nCrZsJsPPZsGzwwsLwLmpwMDw", 'Z')]
    public void GivenListOfItems_WhenCreateElvesByListOfRuckSacks_ThenBadgeValueShouldBeCalculatedCorrectly(string ruckSackGroup, char expectedBadgeValue)
    {
        var sut = new Expedition();

        sut.AddElvesByListOfRuckSacks(ruckSackGroup);

        sut.Elves.Should().AllSatisfy(x => x.RuckSack.Badge.Value.Equals(expectedBadgeValue));
    }

    [Fact]
    public async Task GivenListOfItems_WhenCreateElvesByListOfRuckSacks_ThenSumOfBadgePriorityShouldBeCalculatedCorrectly()
    {
        var expectedPriority = 70;
        var input = await GetInputForDay03();

        var expedition = new Expedition();
        expedition.AddElvesByListOfRuckSacks(input);

        expedition.CalculateSumOfBadgePriority().Should().Be(expectedPriority);
    }

    [Theory]
    [InlineData("2-4,6-8", 0)]
    [InlineData("2-3,4-5", 0)]
    [InlineData("5-7,7-9", 0)]
    [InlineData("2-8,3-7", 1)]
    [InlineData("6-6,4-6", 1)]
    [InlineData("2-6,4-8", 0)]
    public void GivenSectionAssignmentPair_WhenAddElvesBySectionAssignmentPairs_ThenCountOfFullyContainsShouldBeCalculatedCorrectly(string sectionAssignmentPair, int NumberOfFullyContained)
    {
        var sut = new Expedition();

        sut.AddElvesBySectionAssignmentPairs(sectionAssignmentPair);

        sut.NumberOfFullyContainingAssignments.Should().Be(NumberOfFullyContained);
    }

    [Fact]
    public async Task GivenListOfSectionAssignmentPairs_WhenAddElvesBySectionAssignmentPairs_ThenCountOfFullyContainsShouldBeCalculatedCorrectly()
    {
        var expectedNumberOfFullyContainingAssignments = 2;
        var input = await GetInputForDay04();

        var expedition = new Expedition();

        expedition.AddElvesBySectionAssignmentPairs(input);

        expedition.NumberOfFullyContainingAssignments.Should().Be(expectedNumberOfFullyContainingAssignments);
    }

    [Theory]
    [InlineData("2-4,6-8", 0)]
    [InlineData("2-3,4-5", 0)]
    [InlineData("5-7,7-9", 1)]
    [InlineData("2-8,3-7", 1)]
    [InlineData("6-6,4-6", 1)]
    [InlineData("2-6,4-8", 1)]
    public void GivenSectionAssignmentPair_WhenAddElvesBySectionAssignmentPairs_ThenCountOfOverlappingPairsShouldBeCalculatedCorrectly(string sectionAssignmentPair, int NumberOfOverlappingPairs)
    {
        var sut = new Expedition();

        sut.AddElvesBySectionAssignmentPairs(sectionAssignmentPair);

        sut.NumberOfOverlappingPairs.Should().Be(NumberOfOverlappingPairs);
    }

    [Fact]
    public async Task GivenListOfSectionAssignmentPairs_WhenAddElvesBySectionAssignmentPairs_ThenNumberOfOverlappingPairsShouldBeCalculatedCorrectly()
    {
        var expectedNumberOfOverlappingPairs = 4;
        var input = await GetInputForDay04();

        var expedition = new Expedition();

        expedition.AddElvesBySectionAssignmentPairs(input);

        expedition.NumberOfOverlappingPairs.Should().Be(expectedNumberOfOverlappingPairs);
    }

    [Fact]
    public async Task GivenStartingStacksAndRearrangmentProcedure_WhenAddShipByStartingStacksAndRearrangmentProcedure_ThenStacksOnShipShouldBeCorrectGenerated()
    {
        var expectedStacks = StackBuilder.CreateStep4Stacks();
        var input = await GetInputForDay05();

        var expedition = new Expedition();

        expedition.AddShipByStartingStacksAndRearrangmentProcedure(input);

        expedition.Ship.Stacks.Should().BeEquivalentTo(expectedStacks);
    }

    private async Task<string> GetInputForDay01()
    {
        return await File.ReadAllTextAsync($"{_executionPath}/Input/Day01.txt");
    }

    private async Task<string> GetInputForDay03()
    {
        return await File.ReadAllTextAsync($"{_executionPath}/Input/Day03.txt");
    }

    private async Task<string> GetInputForDay04()
    {
        return await File.ReadAllTextAsync($"{_executionPath}/Input/Day04.txt");
    }

    private async Task<string> GetInputForDay05()
    {
        return await File.ReadAllTextAsync($"{_executionPath}/Input/Day05.txt");
    }
}

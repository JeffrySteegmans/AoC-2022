using AoC.Domain.Crane;
using AoC.Domain.Tests.Builders;

namespace AoC.Domain.Tests;

public class ExpeditionTests : Tests
{
    [Fact]
    public async Task GivenInputTextFile_WhenCreateElvesByMeals_ThenShouldHaveCreatedCorrectAmountOfElves()
    {
        var expectedElvesCount = 5;
        var input = await GetInputForDay(1);
        var sut = new Expedition();

        sut.AddElvesByMeals(input);

        sut.Elves.Count.Should().Be(expectedElvesCount);
    }

    [Fact]
    public async Task GivenInputTextFile_WhenGetMaxCalorieCount_ThenShouldReturnCorrectAmount()
    {
        var expectedCalorieCount = 24000;
        var input = await GetInputForDay(1);
        var sut = new Expedition();

        sut.AddElvesByMeals(input);

        sut.GetMaxCalorieCount().Should().Be(expectedCalorieCount);
    }

    [Fact]
    public async Task GivenInputTextFile_WhenGetSumOfTopThreeCalorieCount_ThenShouldReturnCorrectAmount()
    {
        var expectedCalorieCount = 45000;
        var input = await GetInputForDay(1);
        var sut = new Expedition();

        sut.AddElvesByMeals(input);

        sut.GetSumOfTopThreeCalorieCount().Should().Be(expectedCalorieCount);
    }

    [Fact]
    public async Task GivenListOfRuckSacks_WhenCalculateSumOfPriorityOfMisplacedItems_ThenPriorityShouldBeCalculatedCorrectly()
    {
        var expectedPriority = 157;
        var input = await GetInputForDay(3);

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
        var input = await GetInputForDay(3);

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
        var input = await GetInputForDay(4);

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
        var input = await GetInputForDay(4);

        var expedition = new Expedition();

        expedition.AddElvesBySectionAssignmentPairs(input);

        expedition.NumberOfOverlappingPairs.Should().Be(expectedNumberOfOverlappingPairs);
    }

    [Theory]
    [InlineData(CraneVersion.V9000)]
    [InlineData(CraneVersion.V9001)]
    public async Task GivenStartingStacksAndRearrangmentProcedure_WhenAddShipByStartingStacksAndRearrangmentProcedure_ThenStacksOnShipShouldBeCorrectGenerated(CraneVersion craneVersion)
    {
        var expectedStacks = craneVersion switch
        {
            CraneVersion.V9000 => StackBuilder.CreateStep4Stacks(),
            CraneVersion.V9001 => StackBuilder.CreateStep4StacksV9001(),
            _ => throw new ArgumentException("Wrong version")
        };
        var input = await GetInputForDay(5);

        var expedition = new Expedition();

        expedition.AddShipByStartingStacksAndRearrangmentProcedure(input, craneVersion);

        expedition.Ship.Stacks.Should().BeEquivalentTo(expectedStacks);
    }
}

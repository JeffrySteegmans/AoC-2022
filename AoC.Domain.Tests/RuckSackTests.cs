namespace AoC.Domain.Tests;

public class RuckSackTests
{
    [Theory]
    [InlineData("vJrwpWtwJgWrhcsFMMfFFhFp")]
    [InlineData("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL")]
    [InlineData("PmmdzqPrVvPwwTWBwg")]
    [InlineData("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn")]
    [InlineData("ttgJtRGJQctTZtZT")]
    [InlineData("CrZsJsPPZsGzwwsLwLmpwMDw")]
    public void GivenListOfItems_WhenCreatingNewRuckSack_ThenCompartimentsShouldContainCorrectNumberOfItems(string listOfItems)
    {
        var expectedNumberItemsInCompartiment = listOfItems.Length / 2;
        var ruckSack = new RuckSack(listOfItems);

        ruckSack.Compartiment1.Count.Should().Be(expectedNumberItemsInCompartiment);
        ruckSack.Compartiment2.Count.Should().Be(expectedNumberItemsInCompartiment);
    }

    [Theory]
    [InlineData("vJrwpWtwJgWrhcsFMMfFFhFp", 16)]
    [InlineData("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL", 38)]
    [InlineData("PmmdzqPrVvPwwTWBwg", 42)]
    [InlineData("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn", 22)]
    [InlineData("ttgJtRGJQctTZtZT", 20)]
    [InlineData("CrZsJsPPZsGzwwsLwLmpwMDw", 19)]
    public void GivenListOfItems_WhenCalculatePriorityOfMisplacedItems_ThenPriorityShouldBeCalculatedCorrectly(string listOfItems, int expectedPriority)
    {
        var ruckSack = new RuckSack(listOfItems);

        ruckSack.CalculatePriorityOfMisplacedItems().Should().Be(expectedPriority);
    }

}

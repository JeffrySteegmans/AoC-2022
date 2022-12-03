namespace AoC.Domain.Tests;

public class RuckSackItemTests
{
    [Theory]
    [InlineData('p', 16)]
    [InlineData('L', 38)]
    [InlineData('P', 42)]
    [InlineData('v', 22)]
    [InlineData('t', 20)]
    [InlineData('s', 19)]
    public void GivenItemValue_WhenCreatingRuckSackItem_ThenPriorityShouldBeCalculated(char itemValue, int priority)
    {
        var sut = new RuckSackItem(itemValue);

        sut.Priority.Should().Be(priority);
    }

    [Theory]
    [InlineData('p')]
    [InlineData('L')]
    [InlineData('P')]
    [InlineData('v')]
    [InlineData('t')]
    [InlineData('s')]
    public void GivenItemValue_WhenCreatingRuckSackItem_ThenValueShouldBeSetCorrectly(char itemValue)
    {
        var sut = new RuckSackItem(itemValue);

        sut.Value.Should().Be(itemValue);
    }
}

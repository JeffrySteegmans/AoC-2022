namespace AoC.Domain.Tests;

public class RuckSackBadgeTests
{
    [Theory]
    [InlineData('r', 18)]
    [InlineData('Z', 52)]
    public void GivenRuckSackBadgeWithValue_WhenGettingPriority_ThenPriorityShouldBeCorrectValue(char badgeValue, int expectedPriority)
    {
        var sut = new RuckSackBadge(badgeValue);

        sut.Priority.Should().Be(expectedPriority);
    }
}

namespace AoC.Domain.Tests;

public class CrateTests
{
    [Fact]
    public void GivenCrateMark_WhenCreatingNewCrate_ThenCrateMarkingShouldBeFilledIn()
    {
        var expectedMarking = 'M';
        var sut = new Crate(expectedMarking);

        sut.Marking.Should().Be(expectedMarking);
    }
}

namespace AoC.Domain.Tests;

public class CommunicationSystemTests
{
    [Theory]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 6)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
    public void GivenStreamOfData_WhenFindStartOfPacketMarkerIndex_ThenIndexOfMarkerShouldBeCorrect(string stream, int expectedMarkerIndex)
    {
        var sut = new CommunicationSystem(stream);

        sut.FindStartOfPacketMarkerIndex().Should().Be(expectedMarkerIndex);
    }
}

using AoC.Domain.HandheldDevice;

namespace AoC.Domain.Tests.HandheldDevice;

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

    [Theory]
    [InlineData("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
    [InlineData("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
    [InlineData("nppdvjthqldpwncqszvftbrmjlhg", 23)]
    [InlineData("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
    [InlineData("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
    public void GivenStreamOfData_WhenFindStartOfMessageMarkerIndex_ThenIndexOfMarkerShouldBeCorrect(string stream, int expectedMarkerIndex)
    {
        var sut = new CommunicationSystem(stream);

        sut.FindStartOfMessageMarkerIndex().Should().Be(expectedMarkerIndex);
    }
}

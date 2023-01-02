using AoC.Domain.forest;

namespace AoC.Domain.Tests.Forest;

public class TreeMapTests : Tests
{
    [Fact]
    public async Task GivenGeneratedMap_WhenCreateTreeMap_ShouldHaveCorrectNumberOfCollumns()
    {
        var generatedMap = await GetInputForDay(8);

        var treeMap = new TreeMap(generatedMap);

        treeMap.NumberOfCollumns.Should().Be(5);
    }

    [Fact]
    public async Task GivenGeneratedMap_WhenCreateTreeMap_ShouldHaveCorrectNumberOfRows()
    {
        var generatedMap = await GetInputForDay(8);

        var treeMap = new TreeMap(generatedMap);

        treeMap.NumberOfRows.Should().Be(5);
    }
}

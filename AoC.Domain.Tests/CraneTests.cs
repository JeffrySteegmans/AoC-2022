using AoC.Domain.Crane;
using AoC.Domain.Tests.Data;

namespace AoC.Domain.Tests;

public class CraneTests
{
    [Theory]
    [ClassData(typeof(CraneStackData))]
    [ClassData(typeof(CraneStackDataV9001))]
    public void GivenStackList_WhenRearrangeStacks_ThenStacksShouldBeUpdatedCorrectly(Dictionary<int, Stack<Crate>> stacks, string rearrangmentProcedure, Dictionary<int, Stack<Crate>> expectedStacks, CraneVersion craneVersion)
    {
        var crane = CraneFactory.CreateCrane(craneVersion);

        crane.RearrangeStacks(stacks, rearrangmentProcedure);

        stacks.Should().BeEquivalentTo(expectedStacks);
    }
}

using AoC.Domain.Tests.Data;

namespace AoC.Domain.Tests;

public class CraneTests
{
    [Theory]
    [ClassData(typeof(CraneStackData))]
    public void GivenStackList_WhenRearrangeStacks_ThenStacksShouldBeUpdatedCorrectly(Dictionary<int, Stack<Crate>> stacks, string rearrangmentProcedure, Dictionary<int, Stack<Crate>> expectedStacks)
    {
        Crane.RearrangeStacks(stacks, rearrangmentProcedure, CraneVersion.V9000);

        stacks.Should().BeEquivalentTo(expectedStacks);
    }

    [Theory]
    [ClassData(typeof(CraneStackDataV9001))]
    public void GivenStackList_WhenRearrangeStacksV9001_ThenStacksShouldBeUpdatedCorrectly(Dictionary<int, Stack<Crate>> stacks, string rearrangmentProcedure, Dictionary<int, Stack<Crate>> expectedStacks)
    {
        Crane.RearrangeStacks(stacks, rearrangmentProcedure, CraneVersion.V9001);

        stacks.Should().BeEquivalentTo(expectedStacks);
    }
}

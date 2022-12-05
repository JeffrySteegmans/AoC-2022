using AoC.Domain.Tests.Data;

namespace AoC.Domain.Tests;

public class CraneTests
{
    [Theory]
    [ClassData(typeof(CraneStackData))]
    public void GivenStackList_WhenRearrangeStacks_ThenStacksShouldBeUpdatedCorrectly(Dictionary<int, Stack<Crate>> stacks, string rearrangmentProcedure, Dictionary<int, Stack<Crate>> expectedStacks)
    {
        Crane.RearrangeStacks(stacks, rearrangmentProcedure);

        stacks.Should().BeEquivalentTo(expectedStacks);
    }
}

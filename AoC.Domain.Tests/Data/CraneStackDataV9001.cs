using AoC.Domain.Crane;
using AoC.Domain.Tests.Builders;

namespace AoC.Domain.Tests.Data;

public class CraneStackDataV9001 : IEnumerable<object[]>
{
    private readonly List<object[]> _data = new()
    {
        new object[] { StackBuilder.CreateStartingStacks(), "move 1 from 2 to 1", StackBuilder.CreateStep1StacksV9001(), CraneVersion.V9001 },
        new object[] { StackBuilder.CreateStep1StacksV9001(), "move 3 from 1 to 3", StackBuilder.CreateStep2StacksV9001(), CraneVersion.V9001 },
        new object[] { StackBuilder.CreateStep2StacksV9001(), "move 2 from 2 to 1", StackBuilder.CreateStep3StacksV9001(), CraneVersion.V9001 },
        new object[] { StackBuilder.CreateStep3StacksV9001(), "move 1 from 1 to 2", StackBuilder.CreateStep4StacksV9001(), CraneVersion.V9001 }
    };

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

﻿using AoC.Domain.Tests.Builders;

namespace AoC.Domain.Tests.Data;

public class CraneStackData : IEnumerable<object[]>
{
    private readonly List<object[]> _data = new()
    {
        new object[] { StackBuilder.CreateStartingStacks(), "move 1 from 2 to 1", StackBuilder.CreateStep1Stacks() },
        new object[] { StackBuilder.CreateStep1Stacks(), "move 3 from 1 to 3", StackBuilder.CreateStep2Stacks() },
        new object[] { StackBuilder.CreateStep2Stacks(), "move 2 from 2 to 1", StackBuilder.CreateStep3Stacks() },
        new object[] { StackBuilder.CreateStep3Stacks(), "move 1 from 1 to 2", StackBuilder.CreateStep4Stacks() }
    };

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

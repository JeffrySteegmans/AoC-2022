namespace AoC.Domain;

public static class Crane
{
    public static void RearrangeStacks(Dictionary<int, Stack<Crate>> stacks, string rearrangmentProcedure, CraneVersion version)
    {
        (int count, int fromStackIndex, int toStackIndex) = ParseRearrangmentProcedure(rearrangmentProcedure);

        if (version == CraneVersion.V9000)
        {
            RearrangeV9000(stacks, count, fromStackIndex, toStackIndex);
        }
        else
        {
            RearrangeV9001(stacks, count, fromStackIndex, toStackIndex);
        }
    }

    private static void RearrangeV9000(Dictionary<int, Stack<Crate>> stacks, int count, int fromStackIndex, int toStackIndex)
    {
        for (var i = 0; i < count; i++)
        {
            var crate = stacks[fromStackIndex].Pop();
            stacks[toStackIndex].Push(crate);
        }
    }

    private static void RearrangeV9001(Dictionary<int, Stack<Crate>> stacks, int count, int fromStackIndex, int toStackIndex)
    {
        var tempStack = new Stack<Crate>();

        for (var i = 0; i < count; i++)
        {
            var crate = stacks[fromStackIndex].Pop();
            tempStack.Push(crate);
        }

        for (var i = 0; i < count; i++)
        {
            var crate = tempStack.Pop();
            stacks[toStackIndex].Push(crate);
        }
    }

    private static (int count, int fromStackIndex, int toStackIndex) ParseRearrangmentProcedure(string rearrangmentProcedure)
    {
        var procedure = rearrangmentProcedure
            .Split(' ')
            .Where((_, index) => index % 2 != 0)
            .Select(int.Parse)
            .ToList();

        return (procedure[0], procedure[1], procedure[2]);
    }
}

public enum CraneVersion
{
    V9000,
    V9001,
}

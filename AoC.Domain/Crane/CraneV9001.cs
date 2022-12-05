namespace AoC.Domain.Crane;

public class CraneV9001 : Crane
{
    public override CraneVersion CraneVersion => CraneVersion.V9001;

    public override void RearrangeStacks(Dictionary<int, Stack<Crate>> stacks, string rearrangmentProcedure)
    {
        (int count, int fromStackIndex, int toStackIndex) = ParseRearrangmentProcedure(rearrangmentProcedure);

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
}

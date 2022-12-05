namespace AoC.Domain.Crane;

public class CraneV9000 : Crane
{
    public override CraneVersion CraneVersion => CraneVersion.V9000;

    public override void RearrangeStacks(Dictionary<int, Stack<Crate>> stacks, string rearrangmentProcedure)
    {
        (int count, int fromStackIndex, int toStackIndex) = ParseRearrangmentProcedure(rearrangmentProcedure);

        for (var i = 0; i < count; i++)
        {
            var crate = stacks[fromStackIndex].Pop();
            stacks[toStackIndex].Push(crate);
        }
    }
}

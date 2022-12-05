namespace AoC.Domain.Crane;

public abstract class Crane
{
    public abstract CraneVersion CraneVersion { get; }

    public abstract void RearrangeStacks(Dictionary<int, Stack<Crate>> stacks, string rearrangmentProcedure);

    protected static (int count, int fromStackIndex, int toStackIndex) ParseRearrangmentProcedure(string rearrangmentProcedure)
    {
        var procedure = rearrangmentProcedure
            .Split(' ')
            .Where((_, index) => index % 2 != 0)
            .Select(int.Parse)
            .ToList();

        return (procedure[0], procedure[1], procedure[2]);
    }
}

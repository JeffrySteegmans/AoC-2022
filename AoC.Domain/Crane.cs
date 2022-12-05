namespace AoC.Domain;

public static class Crane
{
    public static void RearrangeStacks(Dictionary<int, Stack<Crate>> stacks, string rearrangmentProcedure)
    {
        var procedure = rearrangmentProcedure
            .Split(' ')
            .Where((_, index) => index % 2 != 0)
            .Select(int.Parse)
            .ToList();

        var count = procedure[0];
        var fromStackIndex = procedure[1];
        var toStackIndex = procedure[2];

        for (var i = 0; i < count; i++)
        {
            var crate = stacks[fromStackIndex].Pop();
            stacks[toStackIndex].Push(crate);
        }
    }
}

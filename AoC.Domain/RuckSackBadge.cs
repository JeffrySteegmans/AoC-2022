namespace AoC.Domain;

public class RuckSackBadge
{
    public char Value { get; }
    public int Priority { get; private set; }

    public RuckSackBadge(char value)
    {
        Value = value;
        Priority = CalculatePriority();
    }

    private int CalculatePriority()
    {
        return (int)Value switch
        {
            > 96 and < 123 => Value - 96,
            > 64 and < 91 => Value - 64 + 26,
            _ => 0
        };
    }
}

namespace AoC.Domain;

public class RuckSackItem
{
    public char Value { get; set; }

    public int Priority { get; set; }

    public RuckSackItem(char itemValue)
    {
        Value = itemValue;
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

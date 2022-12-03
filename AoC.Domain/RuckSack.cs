namespace AoC.Domain;

public class RuckSack
{
    public List<char> Compartiment1 { get; } = new();

    public List<char> Compartiment2 { get; } = new();

    public RuckSack(string listOfItems)
    {
        ParseListOfItems(listOfItems);
    }

    public int CalculatePriorityOfMisplacedItems()
    {
        var misplacedCharacter = FindMisplacedCharacter();
        return CalculatePriorityOfCharacter(misplacedCharacter);
    }

    private char FindMisplacedCharacter()
    {
        foreach (var character in Compartiment1)
        {
            if (Compartiment2.Contains(character))
            {
                return character;
            }
        }

        return default;
    }

    private int CalculatePriorityOfCharacter(char character)
    {
        if (character == default)
        {
            return 0;
        }

        return (int)character switch
        {
            > 96 and < 123 => character - 96,
            > 64 and < 91 => character - 64 + 26,
            _ => 0
        };
    }

    private void ParseListOfItems(string listOfItems)
    {
        var midPoint = listOfItems.Length / 2;
        var firstHalf = listOfItems[..midPoint];
        var secondHalf = listOfItems[midPoint..];

        foreach (var character in firstHalf)
        {
            Compartiment1.Add(character);
        }

        foreach (var character in secondHalf)
        {
            Compartiment2.Add(character);
        }
    }
}

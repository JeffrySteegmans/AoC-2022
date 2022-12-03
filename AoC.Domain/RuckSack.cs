namespace AoC.Domain;

public class RuckSack
{
    public List<RuckSackItem> Compartiment1 { get; } = new();

    public List<RuckSackItem> Compartiment2 { get; } = new();

    public List<RuckSackItem> AllItems { get; } = new();

    public RuckSackBadge Badge { get; set; } = default!;

    public RuckSack(string listOfItems)
    {
        ParseListOfItems(listOfItems);
    }

    public int CalculatePriorityOfMisplacedItems()
    {
        var misplacedRuckSackItem = FindMisplacedRuckSackItem();
        return misplacedRuckSackItem.Priority;
    }

    private RuckSackItem FindMisplacedRuckSackItem()
    {
        foreach (var ruckSackItem in Compartiment1)
        {
            if (Compartiment2.Any(x => x.Value == ruckSackItem.Value))
            {
                return ruckSackItem;
            }
        }

        return default;
    }

    private void ParseListOfItems(string listOfItems)
    {
        var midPoint = listOfItems.Length / 2;
        var firstHalf = listOfItems[..midPoint];
        var secondHalf = listOfItems[midPoint..];

        foreach (var character in firstHalf)
        {
            var ruckSackItem = new RuckSackItem(character);
            Compartiment1.Add(ruckSackItem);
            AllItems.Add(ruckSackItem);
        }

        foreach (var character in secondHalf)
        {
            var ruckSackItem = new RuckSackItem(character);
            Compartiment2.Add(ruckSackItem);
            AllItems.Add(ruckSackItem);
        }
    }
}

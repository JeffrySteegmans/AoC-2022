namespace AoC.Domain;

public class Expedition
{
    public List<Elf> Elves { get; private set; } = new();

    public void AddElvesByMeals(string meals)
    {
        var mealsList = meals.Split($"{Environment.NewLine}{Environment.NewLine}");

        foreach (var elfMeal in mealsList)
        {
            var elf = new Elf();
            elf.AddMeals(elfMeal);

            Elves.Add(elf);
        }
    }

    public void AddElvesByListOfRuckSacks(string listOfRuckSacks)
    {
        var itemLists = listOfRuckSacks.Split(Environment.NewLine);
        var ruckSacks = itemLists
            .Select(x => new RuckSack(x))
            .ToList();

        var groupedRuckSacks = GenerateGroups(ruckSacks, 3);
        foreach (var ruckSackGroup in groupedRuckSacks)
        {
            CalculateBadgeValue(ruckSackGroup);

            foreach (var ruckSack in ruckSackGroup)
            {
                var elf = new Elf();
                elf.AddRuckSack(ruckSack);

                Elves.Add(elf);
            }
        }
    }

    private static void CalculateBadgeValue(List<RuckSack> ruckSacks)
    {
        var ruckSacks1Items = ruckSacks[0].AllItems;
        var ruckSacks2Items = ruckSacks[1].AllItems;
        var ruckSacks3Items = ruckSacks[2].AllItems;

        var commonItem = ruckSacks1Items.Select(x => x.Value).ToList()
            .Intersect(ruckSacks2Items.Select(x => x.Value).ToList())
            .Intersect(ruckSacks3Items.Select(x => x.Value).ToList())
            .First();


        foreach (var ruckSack in ruckSacks)
        {
            ruckSack.Badge = new RuckSackBadge(commonItem);
        }
    }

    public static List<List<RuckSack>> GenerateGroups(List<RuckSack> ruckSacks, int amount)
    {
        return ruckSacks
            .Select((x, i) => new { Index = i, Value = x })
            .GroupBy(x => x.Index / amount)
            .Select(x => x.Select(v => v.Value).ToList())
            .ToList();
    }

    public int GetMaxCalorieCount()
    {
        return Elves.Max(x => x.TotalCalories);
    }

    public int GetSumOfTopThreeCalorieCount()
    {
        return Elves
            .Select(x => x.TotalCalories)
            .OrderByDescending(x => x)
            .Take(3)
            .Sum();
    }

    public int CalculateSumOfPriorityOfMisplacedItems()
    {
        return Elves
            .Select(x => x.RuckSack.CalculatePriorityOfMisplacedItems())
            .Sum();
    }

    public int CalculateSumOfBadgePriority()
    {
        var ruckSacks = Elves.Select(x => x.RuckSack).ToList();
        var ruckSackGroups = GenerateGroups(ruckSacks, 3);

        return ruckSackGroups
            .SelectMany(x => x.Select(y => y.Badge.Priority).Distinct())
            .Sum();

        //return Elves
        //    .Select(x => x.RuckSack.Badge.Priority)
        //    .Distinct()
        //    .Sum();
    }
}

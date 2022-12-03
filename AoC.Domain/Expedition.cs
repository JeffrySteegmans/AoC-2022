﻿namespace AoC.Domain;

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

    public void AddElvesByListOfRuckSacks(string ruckSacks)
    {
        var itemLists = ruckSacks.Split(Environment.NewLine);

        foreach (var itemList in itemLists)
        {
            var elf = new Elf();
            elf.AddRuckSack(itemList);

            Elves.Add(elf);
        }
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
}

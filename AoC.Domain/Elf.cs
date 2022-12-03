namespace AoC.Domain;

public class Elf
{
    public List<Meal> Meals { get; } = new();

    public RuckSack RuckSack { get; set; } = default!;

    public int TotalCalories { get; private set; } = 0;

    public void AddMeals(string meals)
    {
        var mealData = meals.Split(Environment.NewLine);

        foreach (var calories in mealData)
        {
            var meal = new Meal(int.Parse(calories.Trim()));

            TotalCalories += meal.calories;
            Meals.Add(meal);
        }
    }

    public void AddRuckSack(string itemList)
    {
        RuckSack = new RuckSack(itemList);
    }
}

namespace AoC.Domain;

public class Elf
{
    public List<Meal> Meals { get; } = new();

    public RuckSack RuckSack { get; set; } = default!;

    public List<CampSection> CampSections { get; set; } = new();

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

    public void AddRuckSack(RuckSack ruckSack)
    {
        RuckSack = ruckSack;
    }

    public void AddCampSection(string assignment)
    {
        var sectionBoundary = assignment.Split('-').Select(x => int.Parse(x));

        CampSections = Enumerable.Range(sectionBoundary.First(), sectionBoundary.Last() - sectionBoundary.First() + 1)
            .Select(x => new CampSection(x))
            .ToList();
    }
}

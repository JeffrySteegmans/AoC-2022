namespace AoC.Domain.Tests;

public class ElfTests
{
    [Theory]
    [InlineData("1000\r\n2000\r\n3000", 3)]
    [InlineData("4000", 1)]
    [InlineData("5000\r\n6000", 2)]
    [InlineData("7000\r\n8000\r\n9000", 3)]
    [InlineData("10000", 1)]
    public void GivenMealsInputString_WhenAddingMealsForElf_ThenElfShouldContainCorrectNumberOfMeals(string meals, int expectedCount)
    {
        var sut = new Elf();

        sut.AddMeals(meals);

        sut.Meals.Count.Should().Be(expectedCount);
    }

    [Theory]
    [InlineData("1000\r\n2000\r\n3000", new[] { 1000, 2000, 3000 })]
    [InlineData("4000", new[] { 4000 })]
    [InlineData("5000\r\n6000", new[] { 5000, 6000 })]
    [InlineData("7000\r\n8000\r\n9000", new[] { 7000, 8000, 9000 })]
    [InlineData("10000", new[] { 10000 })]
    public void GivenMealsInputString_WhenAddingMealsForElf_ThenCaloriesShouldBePresentOnMeals(string meals, int[] expectedCalories)
    {
        var sut = new Elf();

        sut.AddMeals(meals);

        foreach (var calories in expectedCalories)
        {
            sut.Meals.Should().ContainSingle(x => x.calories == calories);
        }
    }

    [Theory]
    [InlineData("1000\r\n2000\r\n3000", 6000)]
    [InlineData("4000", 4000)]
    [InlineData("5000\r\n6000", 11000)]
    [InlineData("7000\r\n8000\r\n9000", 24000)]
    [InlineData("10000", 10000)]
    public void GivenMealsPresentOnElf_WhenGettingTotalCalories_ThenTotalCaloriesShouldBeCalculated(string meals, int expectedTotalCalories)
    {
        var sut = new Elf();

        sut.AddMeals(meals);

        sut.TotalCalories.Should().Be(expectedTotalCalories);
    }

    [Fact]
    public void GivenItemList_WhenAddingRuckSack_ThenRuckSackShouldNotBeNull()
    {
        var itemList = "vJrwpWtwJgWrhcsFMMfFFhFp";
        var sut = new Elf();

        sut.AddRuckSack(itemList);

        sut.RuckSack.Should().NotBeNull();
    }

    [Fact]
    public void GivenRuckSack_WhenAddingRuckSack_ThenRuckSackShouldNotBeNull()
    {
        var ruckSack = new RuckSack("vJrwpWtwJgWrhcsFMMfFFhFp");
        var sut = new Elf();

        sut.AddRuckSack(ruckSack);

        sut.RuckSack.Should().NotBeNull();
    }

    [Theory]
    [InlineData("2-4", 3)]
    public void GivenSectionAssignment_WhenAddCampSections_ThenCorrectNumberOfSectionsShouldBeAdded(string assignment, int numberOfSections)
    {
        var sut = new Elf();

        sut.AddCampSection(assignment);

        sut.CampSections.Count.Should().Be(numberOfSections);
    }

    [Theory]
    [InlineData("2-4", new int[] { 2, 3, 4 })]
    public void GivenSectionAssignment_WhenAddCampSections_ThenCorrectCampSectionIdsShouldBeAdded(string assignment, int[] sectionIds)
    {
        var sut = new Elf();

        sut.AddCampSection(assignment);

        foreach (var id in sectionIds)
        {
            sut.CampSections.Should().ContainSingle(x => x.ID.Equals(id));
        }
    }
}

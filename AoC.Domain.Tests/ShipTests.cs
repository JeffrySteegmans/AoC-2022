using AoC.Domain.Tests.Builders;
using FluentAssertions.Execution;

namespace AoC.Domain.Tests;

public class ShipTests
{
    [Fact]
    public void GivenShipsStartingStackList_WhenCreatingShip_ThenCorrectNumberOfStacksShouldBeGenerated()
    {
        var expectedNumberOfStacks = 3;
        var startingStackList = "    [D]    \r\n[N] [C]    \r\n[Z] [M] [P]\r\n 1   2   3 ";

        var sut = new Ship(startingStackList);

        sut.Stacks.Count.Should().Be(expectedNumberOfStacks);
    }

    [Fact]
    public void GivenShipsStartingStackList_WhenCreatingShip_ThenStacksShouldBeFilledCorrectly()
    {
        var startingStackList = "    [D]    \r\n[N] [C]    \r\n[Z] [M] [P]\r\n 1   2   3 ";
        var expectedStack1 = new Stack<Crate>();
        expectedStack1.Push(new Crate('Z'));
        expectedStack1.Push(new Crate('N'));
        var expectedStack2 = new Stack<Crate>();
        expectedStack2.Push(new Crate('M'));
        expectedStack2.Push(new Crate('C'));
        expectedStack2.Push(new Crate('D'));
        var expectedStack3 = new Stack<Crate>();
        expectedStack3.Push(new Crate('P'));

        var sut = new Ship(startingStackList);

        using (new AssertionScope())
        {
            sut.Stacks[1].Should().BeEquivalentTo(expectedStack1);
            sut.Stacks[2].Should().BeEquivalentTo(expectedStack2);
            sut.Stacks[3].Should().BeEquivalentTo(expectedStack3);
        }
    }

    [Fact]
    public void GivenCraneVersionV9000_WhenRearrangeStacks_ThenShouldGenerateCorrectStackList()
    {
        var startingStackList = "    [D]    \r\n[N] [C]    \r\n[Z] [M] [P]\r\n 1   2   3 ";
        var rearrangmentProcedure = "move 1 from 2 to 1\r\nmove 3 from 1 to 3\r\nmove 2 from 2 to 1\r\nmove 1 from 1 to 2";

        var expectedStacks = StackBuilder.CreateStep4Stacks();

        var sut = new Ship(startingStackList);

        sut.RearrangeCrates(rearrangmentProcedure, CraneVersion.V9000);

        sut.Stacks.Should().BeEquivalentTo(expectedStacks);
    }

    [Fact]
    public void GivenCraneVersionV9000_WhenGetTopCrates_ThenShouldReturnCorrectListOfCrates()
    {
        var expectedTopCrates = new List<Crate>
        {
            new Crate('C'),
            new Crate('M'),
            new Crate('Z'),
        };
        var startingStackList = "    [D]    \r\n[N] [C]    \r\n[Z] [M] [P]\r\n 1   2   3 ";
        var rearrangmentProcedure = "move 1 from 2 to 1\r\nmove 3 from 1 to 3\r\nmove 2 from 2 to 1\r\nmove 1 from 1 to 2";

        var sut = new Ship(startingStackList);
        sut.RearrangeCrates(rearrangmentProcedure, CraneVersion.V9000);

        var topCrates = sut.GetTopCrates();

        topCrates.Should().BeEquivalentTo(expectedTopCrates);
    }

    [Fact]
    public void GivenCraneVersionV9001_WhenRearrangeStacks_ThenShouldGenerateCorrectStackList()
    {
        var startingStackList = "    [D]    \r\n[N] [C]    \r\n[Z] [M] [P]\r\n 1   2   3 ";
        var rearrangmentProcedure = "move 1 from 2 to 1\r\nmove 3 from 1 to 3\r\nmove 2 from 2 to 1\r\nmove 1 from 1 to 2";

        var expectedStacks = StackBuilder.CreateStep4StacksV9001();

        var sut = new Ship(startingStackList);

        sut.RearrangeCrates(rearrangmentProcedure, CraneVersion.V9001);

        sut.Stacks.Should().BeEquivalentTo(expectedStacks);
    }

    [Fact]
    public void GivenCraneVersionV9001_WhenGetTopCrates_ThenShouldReturnCorrectListOfCrates()
    {
        var expectedTopCrates = new List<Crate>
        {
            new Crate('M'),
            new Crate('C'),
            new Crate('D'),
        };
        var startingStackList = "    [D]    \r\n[N] [C]    \r\n[Z] [M] [P]\r\n 1   2   3 ";
        var rearrangmentProcedure = "move 1 from 2 to 1\r\nmove 3 from 1 to 3\r\nmove 2 from 2 to 1\r\nmove 1 from 1 to 2";

        var sut = new Ship(startingStackList);
        sut.RearrangeCrates(rearrangmentProcedure, CraneVersion.V9001);

        var topCrates = sut.GetTopCrates();

        topCrates.Should().BeEquivalentTo(expectedTopCrates);
    }
}

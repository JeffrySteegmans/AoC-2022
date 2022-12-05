namespace AoC.Domain;

public class Ship
{
	public Dictionary<int, Stack<Crate>> Stacks { get; private set; } = new();

	public Ship(string startingStackList)
	{
		CreateStacks(startingStackList);
	}

	private void CreateStacks(string startingStackList)
	{
		var stackList = startingStackList
			.Split(Environment.NewLine)
			.Last()
			.Split("   ")
			.Select(int.Parse);

		foreach (var stackNumber in stackList)
		{
			Stacks.Add(stackNumber, new());
		}

		FillStacks(startingStackList);
	}

	private void FillStacks(string startingStackList)
	{
		var stackNumbers = startingStackList
			.Split(Environment.NewLine)
			.Last()
			.Split("   ")
			.Select(int.Parse);
		var stackList = startingStackList
			.Split(Environment.NewLine)
			.SkipLast(1)
			.Reverse();

		foreach (var stack in stackList)
		{
			var position = 1;
			foreach (var stackNumber in stackNumbers)
			{
				var marking = stack[position];
				if (!string.IsNullOrWhiteSpace(marking.ToString()))
				{
					Stacks[stackNumber].Push(new Crate(marking));
				}
				position += 4;
			}
		}

	}

	public void RearrangeCrates(string rearrangementProcedure)
	{
		foreach (var procedure in rearrangementProcedure.Split(Environment.NewLine))
		{
			Crane.RearrangeStacks(Stacks, procedure);
		}
	}

	public List<Crate> GetTopCrates()
	{
		var crates = new List<Crate>();

		foreach (var stack in Stacks.Values)
		{
			crates.Add(stack.Peek());
		}

		return crates;
	}
}

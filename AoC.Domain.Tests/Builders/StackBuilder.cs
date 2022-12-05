namespace AoC.Domain.Tests.Builders;

internal static class StackBuilder
{
    public static Dictionary<int, Stack<Crate>> CreateStartingStacks()
    {
        return new Dictionary<int, Stack<Crate>>
        {
            {
                1,
                new Stack<Crate>(new List<Crate>
                {
                    new Crate('Z'),
                    new Crate('N'),
                })
            },
            {
                2,
                new Stack<Crate>(new List<Crate>
                {
                    new Crate('M'),
                    new Crate('C'),
                    new Crate('D'),
                })
            },
            {
                3,
                new Stack<Crate>(new List<Crate>
                {
                    new Crate('P'),
                })
            }
        };
    }

    public static Dictionary<int, Stack<Crate>> CreateStep1Stacks()
    {
        return new Dictionary<int, Stack<Crate>>
        {
            {
                1,
                new Stack<Crate>(new List<Crate>
                {
                    new Crate('Z'),
                    new Crate('N'),
                    new Crate('D'),
                })
            },
            {
                2,
                new Stack<Crate>(new List<Crate>
                {
                    new Crate('M'),
                    new Crate('C'),
                })
            },
            {
                3,
                new Stack<Crate>(new List<Crate>
                {
                    new Crate('P'),
                })
            }
        };
    }

    public static Dictionary<int, Stack<Crate>> CreateStep2Stacks()
    {
        return new Dictionary<int, Stack<Crate>>
        {
            {
                1,
                new Stack<Crate>()
            },
            {
                2,
                new Stack<Crate>(new List<Crate>
                {
                    new Crate('M'),
                    new Crate('C'),
                })
            },
            {
                3,
                new Stack<Crate>(new List<Crate>
                {
                    new Crate('P'),
                    new Crate('D'),
                    new Crate('N'),
                    new Crate('Z'),
                })
            }
        };
    }

    public static Dictionary<int, Stack<Crate>> CreateStep3Stacks()
    {
        return new Dictionary<int, Stack<Crate>>
        {
            {
                1,
                new Stack<Crate>(new List<Crate>
                {
                    new Crate('C'),
                    new Crate('M'),
                })
            },
            {
                2,
                new Stack<Crate>()
            },
            {
                3,
                new Stack<Crate>(new List<Crate>
                {
                    new Crate('P'),
                    new Crate('D'),
                    new Crate('N'),
                    new Crate('Z'),
                })
            }
        };
    }

    public static Dictionary<int, Stack<Crate>> CreateStep4Stacks()
    {
        return new Dictionary<int, Stack<Crate>>
        {
            {
                1,
                new Stack<Crate>(new List<Crate>
                {
                    new Crate('C'),
                })
            },
            {
                2,
                new Stack<Crate>(new List<Crate>
                {
                    new Crate('M'),
                })
            },
            {
                3,
                new Stack<Crate>(new List<Crate>
                {
                    new Crate('P'),
                    new Crate('D'),
                    new Crate('N'),
                    new Crate('Z'),
                })
            }
        };
    }
}

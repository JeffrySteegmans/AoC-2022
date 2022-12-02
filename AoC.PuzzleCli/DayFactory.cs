using AoC.PuzzleCli.Days;

namespace AoC.PuzzleCli;

internal static class DayFactory
{
    public static IDay Create(int dayNumber)
    {
        switch (dayNumber)
        {
            case 1:
                return new Day01();
            case 2:
                return new Day02();
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}

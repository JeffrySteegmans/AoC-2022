namespace AoC.PuzzleCli.Days;

public class Day06 : Day
{
    public Day06() : base("06")
    {
    }

    public override CalculationResults CalculateResults()
    {
        var communicationSystem = new CommunicationSystem(_input);

        var resultPart1 = communicationSystem.FindStartOfPacketMarkerIndex();
        var resultPart2 = "";

        return new CalculationResults(resultPart1.ToString(), resultPart2);
    }
}

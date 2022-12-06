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
        var resultPart2 = communicationSystem.FindStartOfMessageMarkerIndex();

        return new CalculationResults(resultPart1.ToString(), resultPart2.ToString());
    }
}

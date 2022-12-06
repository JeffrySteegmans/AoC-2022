namespace AoC.Domain;

public class CommunicationSystem
{
    private readonly string _stream;

    public CommunicationSystem(string stream)
    {
        _stream = stream;
    }

    public int FindStartOfPacketMarkerIndex()
    {
        var startSequence = new Queue<char>();

        var position = 0;
        foreach (var character in _stream)
        {
            position++;
            if (startSequence.Count == 4)
            {
                startSequence.Dequeue();
            }

            startSequence.Enqueue(character);

            var isDistinctSequence = startSequence.Distinct().Count() == 4;
            if (isDistinctSequence)
            {
                break;
            }
        }

        return position;
    }
}

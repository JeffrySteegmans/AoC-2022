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
        return FindStartMarker(4);
    }

    public int FindStartOfMessageMarkerIndex()
    {
        return FindStartMarker(14);
    }

    private int FindStartMarker(int numberOfDistinctCharacters)
    {
        var startSequence = new Queue<char>();

        var position = 0;
        foreach (var character in _stream)
        {
            position++;
            if (startSequence.Count == numberOfDistinctCharacters)
            {
                startSequence.Dequeue();
            }

            startSequence.Enqueue(character);

            var isDistinctSequence = startSequence.Distinct().Count() == numberOfDistinctCharacters;
            if (isDistinctSequence)
            {
                break;
            }
        }

        return position;
    }
}

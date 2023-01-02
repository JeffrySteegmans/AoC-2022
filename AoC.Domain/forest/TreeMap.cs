namespace AoC.Domain.forest;

public class TreeMap
{
    private readonly List<Tree> _trees = new List<Tree>();

    public int NumberOfCollumns { get; private set; }
    public object NumberOfRows { get; set; }

    public TreeMap(string generatedMap)
    {
        Parse(generatedMap);
    }

    private void Parse(string generatedMap)
    {
        var treeRows = generatedMap.Split(Environment.NewLine);

        NumberOfCollumns = treeRows.First().Length;
        NumberOfRows = treeRows.Length;

        for (var i = 0; i < treeRows.Length; i++)
        {
            var trees = treeRows[i]
                .Select((x, index) => new Tree(int.Parse(x.ToString()), index, i));

            _trees.Add(new Tree())
        }
    }
}

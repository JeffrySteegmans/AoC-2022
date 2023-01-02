namespace AoC.Domain.forest;

public class Tree
{
    public Tree(int treeHeight, int rowIndex, int colIndex)
    {
        TreeHeight = treeHeight;
        RowIndex = rowIndex;
        ColIndex = colIndex;
    }

    public int TreeHeight { get; }

    public int RowIndex { get; }

    public int ColIndex { get; }
}

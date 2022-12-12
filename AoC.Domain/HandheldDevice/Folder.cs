namespace AoC.Domain.HandheldDevice;

public class Folder
{
    public Folder(string folderName, string path)
    {
        Name = folderName;
        Path = path;
    }

    public string Name { get; set; } = string.Empty;

    public List<Folder> Folders { get; init; } = new();

    public List<File> Files { get; init; } = new();

    public string Path { get; init; }

    public int Size()
    {
        var totalSize = 0;

        foreach (var folder in Folders)
        {
            totalSize += folder.Size();
        }

        totalSize += Files
            .Select(x => x.FileSize)
            .Sum();

        return totalSize;
    }
}

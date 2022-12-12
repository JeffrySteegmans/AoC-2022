using AoC.Domain.HandheldDevice.Terminal;
using AoC.Domain.HandheldDevice.Terminal.Commands;

namespace AoC.Domain.HandheldDevice;

public class FileSystem
{
    private const int TotalDiskSpace = 70000000;

    public Folder ActiveFolder { get; private set; }

    public Folder Root { get; } = new("/", "/");

    public FileSystem()
    {
        ActiveFolder = Root;
    }

    public void ApplyTerminalOutput(string terminalOutput)
    {
        var commands = TerminalOutputParser.Parse(terminalOutput);

        commands
            .ForEach(Apply);
    }

    private void Apply(ICommand command)
    {
        switch (command)
        {
            case ChangeDirectory changeDirectory: Apply(changeDirectory); break;
            case ListDirectoryContent listDirectoryContent: Apply(listDirectoryContent); break;
            default: throw new ArgumentException($"{nameof(command)} is not a valid command");
        }
    }

    private void Apply(ChangeDirectory changeDirectoryCommand)
    {
        if (changeDirectoryCommand.DirectoryName is "/")
        {
            ActiveFolder = Root;
            return;
        }

        if (changeDirectoryCommand.DirectoryName is "..")
        {
            var path = ActiveFolder.Path[..^ActiveFolder.Name.Length];
            var folder = FindFolder(Root, path);
            if (folder is null)
            {
                throw new Exception($"Folder '{path}' not found");
            }
            ActiveFolder = folder;
            return;
        }

        ActiveFolder = ActiveFolder.Folders.Single(x => x.Path == ActiveFolder.Path + changeDirectoryCommand.DirectoryName);
    }

    private void Apply(ListDirectoryContent listDirectoryCommand)
    {
        ActiveFolder?.Folders.AddRange(
            listDirectoryCommand.Output
                .Where(x => x.Type == ListDirectoryOutputType.Folder)
                .Where(x => !ActiveFolder?.Folders.Any(folder => folder.Name == x.Name) ?? false)
                .Select(x => new Folder(x.Name, ActiveFolder.Path + x.Name))
        );

        ActiveFolder?.Files.AddRange(
            listDirectoryCommand.Output
                .Where(x => x.Type == ListDirectoryOutputType.File)
                .Where(x => !ActiveFolder?.Files.Any(file => file.Name == x.Name) ?? false)
                .Select(x => new File(x.Name, x.FileSize))
        );
    }

    private Folder? FindFolder(Folder folder, string path)
    {
        if (folder.Path == path)
        {
            return folder;
        }

        foreach (var subFolder in folder.Folders)
        {
            var result = FindFolder(subFolder, path);
            if (result is not null)
            {
                return result;
            }
        }

        return default;
    }

    public int GetSumOfFoldersWithMaxSize(int maxSize)
    {
        var folders = new List<Folder>();

        GetFoldersWithMaxSize(maxSize, Root, folders);

        return folders
            .Select(x => x.Size())
            .Sum();
    }

    private void GetFoldersWithMaxSize(int maxSize, Folder currentFolder, List<Folder> folders)
    {
        if (currentFolder.Size() <= maxSize)
        {
            folders.Add(currentFolder);
        }

        foreach (var folder in currentFolder.Folders)
        {
            GetFoldersWithMaxSize(maxSize, folder, folders);
        }
    }

    public int GetTotalAmountOfUsedSpace()
    {
        return Root.Size();
    }

    public int GetTotalAmountOfUnusedSpace()
    {
        return TotalDiskSpace - GetTotalAmountOfUsedSpace();
    }

    public int GetSizeOfSmallestDirectoryToDelete(int requiredSpace)
    {
        var folderSizes = new List<int>();

        GetFoldersToDelete(requiredSpace, Root, folderSizes);

        return folderSizes
            .Min();
    }

    private void GetFoldersToDelete(int requiredSpace, Folder currentFolder, List<int> folderSizes)
    {
        var currentFolderSize = currentFolder.Size();

        if (GetTotalAmountOfUnusedSpace() + currentFolderSize >= requiredSpace)
        {
            folderSizes.Add(currentFolderSize);
        }

        foreach (var subFolder in currentFolder.Folders)
        {
            GetFoldersToDelete(requiredSpace, subFolder, folderSizes);
        }
    }
}

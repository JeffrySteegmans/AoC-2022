using AoC.Domain.HandheldDevice;
using File = AoC.Domain.HandheldDevice.File;

namespace AoC.Domain.Tests.HandheldDevice;

public class FileSystemTests : Tests
{
    [Fact]
    public void GivenChangeDirectoryTerminalOutput_WhenApplyTerminalOutput_ThenFolderShouldBeTheActiveFolder()
    {
        var expectedActiveFolder = new Folder("/", "/");
        var command = "$ cd /";
        var sut = new FileSystem();

        sut.ApplyTerminalOutput(command);

        sut.ActiveFolder.Should().BeEquivalentTo(expectedActiveFolder);
    }

    [Fact]
    public void GivenListDirectoryTerminalOutput_WhenApplyTerminalOutput_ThenFoldersShouldBeCreated()
    {
        var expectedFolders = new List<Folder>
        {
            new Folder("a", "/a"),
            new Folder("d", "/d"),
        };

        var command = "$ ls\r\ndir a\r\n14848514 b.txt\r\n8504156 c.dat\r\ndir d";
        var sut = new FileSystem();
        sut.ApplyTerminalOutput("$ cd /");

        sut.ApplyTerminalOutput(command);

        sut.ActiveFolder.Folders.Should().BeEquivalentTo(expectedFolders);
    }

    [Fact]
    public void GivenListDirectoryTerminalOutput_WhenApplyTerminalOutput_ThenFilesShouldBeCreated()
    {
        var expectedFiles = new List<File>
        {
            new File("b.txt", 14848514),
            new File("c.dat", 8504156),
        };

        var command = "$ ls\r\ndir a\r\n14848514 b.txt\r\n8504156 c.dat\r\ndir d";
        var sut = new FileSystem();
        sut.ApplyTerminalOutput("$ cd /");

        sut.ApplyTerminalOutput(command);

        sut.ActiveFolder.Files.Should().BeEquivalentTo(expectedFiles);
    }

    [Fact]
    public void GivenRootDirectoryWithSubFolder_WhenChangeFolder_ThenActiveFolderShouldBeSubFolder()
    {
        var terminalOutput = "$ cd /\r\n$ ls\r\ndir a\r\n14848514 b.txt\r\n8504156 c.dat\r\ndir d\r\n$ cd a";
        var expectedSubFolder = new Folder("a", "/a");

        var sut = new FileSystem();
        sut.ApplyTerminalOutput(terminalOutput);

        sut.ActiveFolder.Should().BeEquivalentTo(expectedSubFolder);
    }

    [Fact]
    public async Task GivenMultipleDirectoryTerminalOutput_WhenApplyTerminalOutput_ThenFolderStructureShouldBeCreated()
    {
        var rootFolder = new Folder("/", "/")
        {
            Folders = new()
            {
                new Folder("a", "/a")
                {
                    Folders= new()
                    {
                        new Folder("e", "/ae")
                        {
                            Files = new()
                            {
                                new File("i", 584)
                            }
                        }
                    },
                    Files = new()
                    {
                        new File("f", 29116),
                        new File("g", 2557),
                        new File("h.lst", 62596),
                    }
                },
                new Folder("d", "/d")
                {
                    Files = new()
                    {
                        new File("j", 4060174),
                        new File("d.log", 8033020),
                        new File("d.ext", 5626152),
                        new File("k", 7214296),
                    }
                }
            },
            Files = new()
            {
                new File("b.txt", 14848514),
                new File("c.dat", 8504156),
            }
        };
        var terminalOutput = await GetInputForDay(7);
        var sut = new FileSystem();

        sut.ApplyTerminalOutput(terminalOutput);

        sut.Root.Should().BeEquivalentTo(rootFolder);
    }

    [Fact]
    public async Task GivenMultipleDirectoryTerminalOutput_WhenGetSumOfFoldersWithMaxSize_ThenCorrectListOfFoldersShouldBeReturned()
    {
        var maxSize = 100000;
        var expectedSum = 95437;
        var terminalOutput = await GetInputForDay(7);

        var sut = new FileSystem();
        sut.ApplyTerminalOutput(terminalOutput);

        sut.GetSumOfFoldersWithMaxSize(maxSize).Should().Be(expectedSum);
    }

    [Fact]
    public async Task GivenMultipleDirectoryTerminalOutput_WhenGetTotalAmountOfUsedSpace_ThenReturnCorrectAmount()
    {
        var expectedAmount = 48381165;
        var terminalOutput = await GetInputForDay(7);

        var sut = new FileSystem();
        sut.ApplyTerminalOutput(terminalOutput);

        sut.GetTotalAmountOfUsedSpace().Should().Be(expectedAmount);

    }

    [Fact]
    public async Task GivenMultipleDirectoryTerminalOutput_WhenGetTotalAmountOfUnusedSpace_ThenReturnCorrectAmount()
    {
        var expectedAmount = 21618835;
        var terminalOutput = await GetInputForDay(7);

        var sut = new FileSystem();
        sut.ApplyTerminalOutput(terminalOutput);

        sut.GetTotalAmountOfUnusedSpace().Should().Be(expectedAmount);
    }

    [Fact]
    public async Task GivenMultipleDirectoryTerminalOutput_WhenGetSizeOfSmallestDirectoryToDelete_ThenReturnCorrectSize()
    {
        var expectedAmount = 24933642;
        var terminalOutput = await GetInputForDay(7);

        var sut = new FileSystem();
        sut.ApplyTerminalOutput(terminalOutput);

        sut.GetSizeOfSmallestDirectoryToDelete(30000000).Should().Be(expectedAmount);
    }
}

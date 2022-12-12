using AoC.Domain.HandheldDevice;
using File = AoC.Domain.HandheldDevice.File;

namespace AoC.Domain.Tests.HandheldDevice;

public class FolderTests
{
    [Fact]
    public void GivenFolderWithFiles_WhenGetFolderSize_ThenShouldReturnCorrectFolderSize()
    {
        var expectedFolderSize = 25426;
        var sut = new Folder("test", "test")
        {
            Files = new()
            {
                new File("a", 100),
                new File("b", 250),
                new File("c", 3500),
                new File("d", 21576),
            }
        };

        sut.Size().Should().Be(expectedFolderSize);
    }

    [Fact]
    public void GivenFolderWithSubFolders_WhenGetFolderSize_ThenShouldReturnCorrectFolderSize()
    {
        var expectedFolderSize = 25426;
        var sut = new Folder("test", "test")
        {
            Folders = new()
            {
                new Folder("SubFolder", "SubFolder")
                {
                    Folders = new()
                    {
                        new Folder("SubSubFolder", "SubSubFolder")
                        {
                            Files = new()
                            {
                                new File("a", 100),
                                new File("b", 250),
                                new File("c", 3500),
                                new File("d", 21576),
                            }
                        }
                    }
                }
            }
        };

        sut.Size().Should().Be(expectedFolderSize);
    }

    [Fact]
    public void GivenFolderWithFilesAndSubFolders_WhenGetFolderSize_ThenShouldReturnCorrectFolderSize()
    {
        var expectedFolderSize = 25426;
        var sut = new Folder("test", "test")
        {
            Folders = new()
            {
                new Folder("SubFolder", "SubFolder")
                {
                    Folders = new()
                    {
                        new Folder("SubSubFolder", "SubSubFolder")
                        {
                            Files = new()
                            {
                                new File("b", 250),
                            }
                        }
                    },
                    Files = new()
                    {
                        new File("c", 3500),
                        new File("d", 21576),
                    }
                }
            },
            Files = new()
            {
                new File("a", 100)
            }
        };

        sut.Size().Should().Be(expectedFolderSize);
    }
}

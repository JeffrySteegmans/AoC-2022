using AoC.Domain.HandheldDevice.Terminal;
using AoC.Domain.HandheldDevice.Terminal.Commands;
using FluentAssertions.Execution;

namespace AoC.Domain.Tests.HandheldDevice;

public class TerminalOutputParserTests
{
    [Fact]
    public void GivenOutputWithCdCommand_WhenParsingOutput_ThenSingleChangeDirectoryCommandShouldBeReturned()
    {
        var expectedDirectoryName = "/";
        var terminalOutput = "$ cd /";

        var commands = TerminalOutputParser.Parse(terminalOutput);

        var command = commands.Should().ContainSingle().Subject;
        var changeDirectoryCommand = command.Should().BeOfType<ChangeDirectory>().Subject;
        changeDirectoryCommand.DirectoryName.Should().Be(expectedDirectoryName);
    }

    [Fact]
    public void GivenOutputWithLsCommand_WhenParsingOutput_ThenSingleListDirectoryContentCommandShouldBeReturned()
    {
        var terminalOutput = "$ ls";

        var commands = TerminalOutputParser.Parse(terminalOutput);

        var command = commands.Should().ContainSingle().Subject;
        command.Should().BeOfType<ListDirectoryContent>();
    }

    [Fact]
    public void GivenOutputWithLsCommandAndOutput_WhenParsingOutput_ThenSingleListDirectoryContentCommandShouldBeReturnedWithOutputLines()
    {
        var terminalOutput = "$ ls\r\ndir a\r\n14848514 b.txt\r\n8504156 c.dat\r\ndir d";
        var expectedListDirectoryOutput = new List<ListDirectoryOutput>
        {
            new ListDirectoryOutput(Type: ListDirectoryOutputType.Folder, Name: "a"),
            new ListDirectoryOutput(Type: ListDirectoryOutputType.File, Name: "b.txt", 14848514),
            new ListDirectoryOutput(Type: ListDirectoryOutputType.File, Name: "c.dat", 8504156),
            new ListDirectoryOutput(Type: ListDirectoryOutputType.Folder, Name: "d"),
        };

        var commands = TerminalOutputParser.Parse(terminalOutput);

        using (new AssertionScope())
        {
            var command = commands.Should().ContainSingle().Subject as ListDirectoryContent;

            command!.Output.Count.Should().Be(4);
            command.Output.Should().BeEquivalentTo(expectedListDirectoryOutput);
        }
    }
}

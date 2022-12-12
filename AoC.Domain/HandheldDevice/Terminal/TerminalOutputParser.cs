using AoC.Domain.HandheldDevice.Terminal.Commands;

namespace AoC.Domain.HandheldDevice.Terminal;

public static class TerminalOutputParser
{
    public static List<ICommand> Parse(string terminalOutput)
    {
        var commands = new List<ICommand>();

        var outputLines = terminalOutput.Split(Environment.NewLine).ToList();
        for (var i = 0; i < outputLines.Count; i++)
        {
            var line = outputLines[i];

            if (!IsCommand(line))
            {
                continue;
            }

            var lineParts = line.Split(' ');
            ICommand command;
            switch (lineParts[1])
            {
                case "cd":
                    command = new ChangeDirectory(lineParts[2]);
                    break;
                case "ls":
                    var listDirectoryOutput = new List<ListDirectoryOutput>();

                    while (i < outputLines.Count - 1 && !IsCommand(outputLines[i + 1]))
                    {
                        var outputLine = outputLines[i + 1];
                        var output = outputLine.Split(' ') switch
                        {
                            ["dir", string name] => new ListDirectoryOutput(ListDirectoryOutputType.Folder, name),
                            [string filesize, string name] => new ListDirectoryOutput(ListDirectoryOutputType.File, name, int.Parse(filesize)),
                            _ => throw new ArgumentException($"{outputLine} is not a valid output")
                        };
                        listDirectoryOutput.Add(output);

                        i++;
                    }

                    command = new ListDirectoryContent(listDirectoryOutput);
                    break;
                default:
                    throw new ArgumentException($"{lineParts[1]} is a unknown command");
            }

            commands.Add(command);
        }

        return commands;
    }

    private static bool IsCommand(string line)
    {
        return line.StartsWith('$');
    }
}

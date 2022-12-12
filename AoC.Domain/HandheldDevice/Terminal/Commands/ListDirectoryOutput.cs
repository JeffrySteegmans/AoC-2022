namespace AoC.Domain.HandheldDevice.Terminal.Commands;

public record class ListDirectoryOutput(ListDirectoryOutputType Type, string Name, int FileSize = 0);

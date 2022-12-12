namespace AoC.Domain.HandheldDevice.Terminal.Commands;

public record class ListDirectoryContent(List<ListDirectoryOutput> Output) : ICommand;

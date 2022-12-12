namespace AoC.Domain.HandheldDevice.Terminal.Commands;

public record class ChangeDirectory(string DirectoryName) : ICommand;

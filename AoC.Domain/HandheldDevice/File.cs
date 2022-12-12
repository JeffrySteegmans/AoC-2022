namespace AoC.Domain.HandheldDevice;

public record class File(string Name, int FileSize = 0)
{
    public static Task<string> ReadAllTextAsync(string v)
    {
        throw new NotImplementedException();
    }
}

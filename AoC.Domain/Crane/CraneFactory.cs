namespace AoC.Domain.Crane;

public static class CraneFactory
{
    public static Crane CreateCrane(CraneVersion craneVersion) => craneVersion switch
    {
        CraneVersion.V9000 => new CraneV9000(),
        CraneVersion.V9001 => new CraneV9001(),
        _ => throw new ArgumentException($"CraneVersion {craneVersion} is not a valid version"),
    };
}

namespace Territory.Type;

internal record struct Config
{
    private (ulong, ulong) minMax;

    public int MaxLandsPerPlayer { get; init; }
    public (uint, uint, uint) Price { get; init; }
    public (ulong, ulong) MinMax
    {
        get => minMax;
        init => minMax = value.Item1 >= value.Item2 ? value : (value.Item2, value.Item1);
    }
    public (bool, bool, bool) AvailableDimension { get; init; }
}

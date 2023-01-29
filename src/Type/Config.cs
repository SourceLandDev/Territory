namespace Territory.Type;

internal struct Config
{
    private (ulong, ulong) minMax;

    public int MaxLandsPerPlayer { get; init; }
    public (uint, uint, uint) Price { get; init; }
    public (ulong, ulong) MinMax
    {
        get => minMax;
        init
        {
            if (value.Item2 > value.Item1)
            {
                throw new InvalidValueException("Min value is bigger than max value");
            }
            minMax = value;
        }
    }
    public (bool, bool, bool) AvailableDimension { get; init; }
}

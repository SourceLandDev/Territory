using Territory.Utils;

namespace Territory.Type;

internal struct Config
{
    private (ulong, ulong) minMax;

    public int MaxLandsPerPlayer { get; set; }
    public (uint, uint, uint) Price { get; set; }
    public (ulong, ulong) MinMax
    {
        get => minMax;
        set
        {
            if (value.Item2 > value.Item1)
            {
                throw new InvalidValueException("Min value is bigger than max value");
            }
            minMax = value;
        }
    }
    public Helper.Dimension AvailableDimension { get; set; }
    public string DefaultLanguage { get; set; }
}

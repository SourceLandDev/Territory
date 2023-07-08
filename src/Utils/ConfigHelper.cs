namespace Territory.Utils;

internal record ConfigHelper(int MaxLandsPerPlayer, (uint, uint, uint) Price, (bool, bool, bool) AvailableDimension)
{
    private (ulong, ulong) minMax;

    public (ulong, ulong) MinMax
    {
        get => minMax;
        set => minMax = value.Item1 >= value.Item2 ? value : (value.Item2, value.Item1);
    }
    internal ConfigHelper(string path) : this(default, default, default)
    {
        string configStr = FileHelper.CheckFile(path, JsonSerializer.Serialize(this));
        ConfigHelper config = JsonSerializer.Deserialize<ConfigHelper>(configStr);
        MaxLandsPerPlayer = config.MaxLandsPerPlayer;
        Price = config.Price;
        MinMax = config.MinMax;
        AvailableDimension = config.AvailableDimension;
    }
}

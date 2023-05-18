namespace Territory.Utils;

internal record ConfigHelper
{
    private (ulong, ulong) minMax;

    internal int MaxLandsPerPlayer { get; private set; }
    internal (uint, uint, uint) Price { get; private set; }
    internal (ulong, ulong) MinMax
    {
        get => minMax;
        private set => minMax = value.Item1 >= value.Item2 ? value : (value.Item2, value.Item1);
    }
    internal (bool, bool, bool) AvailableDimension { get; private set; }
    internal ConfigHelper(string path)
    {
        string configStr = FileHelper.CheckFile(path, JsonSerializer.Serialize(this));
        ConfigHelper config = JsonSerializer.Deserialize<ConfigHelper>(configStr);
        MaxLandsPerPlayer = config.MaxLandsPerPlayer;
        Price = config.Price;
        MinMax = config.MinMax;
        AvailableDimension = config.AvailableDimension;
    }
}

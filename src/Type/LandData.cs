namespace Territory.Type;

internal class LandData
{
    public AABB Pos { get; set; }
    public int Dimension { get; set; }
    public string Owner { get; set; }
    public string Name { get; set; }
    public Dictionary<string, Permission.Player> Collaborators { get; set; }
    public Permissions Permissions { get; set; }
    public LandData[] SubLands { get; set; }
#nullable enable
    public LandData? Father { get; set; }
    public uint Price { get; set; }
}

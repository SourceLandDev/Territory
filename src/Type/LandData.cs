namespace Territory.Type;

internal struct LandData
{
    internal AABB Pos { get; set; }
    internal int Dimension { get; set; }
    internal string Owner { get; set; }
    internal string Name { get; set; }
    internal Dictionary<string, Permission.Player> Collaborators { get; set; }
    internal Permissions Permissions { get; set; }
    internal LandData[] SubLands { get; set; }
    internal uint Price { get; set; }
}

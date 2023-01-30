namespace Territory.Type;

internal class LandData
{
    internal AABB Pos { get; set; }
    internal int Dimension { get; set; }
    internal string Owner { get; set; }
    internal string Name { get; set; }
    internal Dictionary<string, Permission.Player> Collaborators { get; set; }
    internal Permissions Permissions { get; set; }
    internal LandData[] SubLands { get; set; }
#nullable enable
    internal LandData? Father { get; set; }
    internal uint Price { get; set; }
}

using Territory.Utils;

namespace Territory.Type;

internal struct LandData
{
    internal AABB Pos { get; set; }
    internal Helper.Dimension Dimension { get; set; }
    internal string Owner { get; set; }
    internal string Name { get; set; }
    internal Dictionary<string, Permissions> Collaborators { get; set; }
    internal Permissions Permissions { get; set; }
    internal LandData[] SubLands { get; set; }
    internal uint Price { get; set; }
}

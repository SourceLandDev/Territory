using System.Diagnostics.CodeAnalysis;
using Territory.Type;

namespace Territory.Utils;

internal static class LandHelper
{
    internal static bool TryGetLand(this Vec3 pos, int dim, [NotNullWhen(true)] out LandData land)
    {
        LandData[] lands = new AABB(pos, pos).GetLands(dim);
        if (lands.Length > 1)
        {
            throw new InvalidDataException("Data err0r - Too much lands! xwx");
        }
        if (lands.Length > 0)
        {
            land = lands[0];
            return true;
        }
        land = default;
        return false;
    }
    internal static LandData[] GetLands(this AABB aabb, float dim)
    {
        ILiteCollection<LandData> col = Main.DataBase.GetCollection<LandData>("lands");
        return (from land in col.Find(x => x.Dimension == dim) where land.Bounding.Intersects(aabb) select land).ToArray();
    }
    internal static bool HasPermission(this LandData data, string xuid, string type = default) => data.Owner == xuid || !string.IsNullOrWhiteSpace(type) && (data.Collaborators.TryGetValue(xuid, out Type.Permission.Player permissions) ? permissions[type] : data.Permissions.Player[type]);
}

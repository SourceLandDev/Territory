using System.Numerics;
using Territory.Type;

namespace Territory.Utils;

internal static class LandHelper
{
    internal static bool TryGetLandsByPos(this Vector4 pos, out LandData land) => TryGetLandsByPos(pos.X, pos.Y, pos.Z, Convert.ToInt32(pos.W), out land);
    internal static bool TryGetLandsByPos(this BlockPos pos, int dim, out LandData land) => TryGetLandsByPos(pos.X, pos.Y, pos.Z, dim, out land);
    internal static bool TryGetLandsByPos(this Vec3 pos, int dim, out LandData land) => TryGetLandsByPos(pos.X, pos.Y, pos.Z, dim, out land);
    internal static bool TryGetLandsByPos(this Vector3 pos, int dim, out LandData land) => TryGetLandsByPos(pos.X, pos.Y, pos.Z, dim, out land);
    internal static bool TryGetLandsByPos(float x, float y, float z, int dim, out LandData land)
    {
        List<LandData> lands = new AABB(x, y, z, x, y, z).GetLands(dim);
        if (lands.Count > 1)
        {
            throw new InvalidDataException("Too much lands! xwx");
        }
        if (lands.Count > 0)
        {
            land = lands[0];
            return true;
        }
        land = default;
        return false;
    }
    internal static List<LandData> GetLands(this AABB aabb, int dim)
    {
        List<LandData> list = new();
        ILiteCollection<LandData> col = Main.DataBase.GetCollection<LandData>("lands");
        IEnumerable<LandData> find = col.Find(e => e.Pos.Intersects(aabb) && e.Dimension == dim);
        list.AddRange(find);
        return list;
    }
    internal static bool HasPermission(this Player player, LandData data, string type) => HasPermission(player.Xuid, data, type);
    internal static bool HasPermission(string xuid, LandData data, string type) => data.Owner == xuid || (data.Collaborators.TryGetValue(xuid, out Type.Permission.Player permissions) ? permissions[type] : data.Permissions.Player[type]);
}

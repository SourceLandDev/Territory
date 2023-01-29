#nullable enable
using System.Numerics;
using Territory.Type;

namespace Territory.Utils;

internal static class LandHelper
{
    internal static bool TryGetLandsByPos(this Vector4 pos, out LandData land) => TryGetLandsByPos(pos.X, pos.Y, pos.Z, Helper.GetDimensionFromDimID(Convert.ToInt32(pos.W)), out land);
    internal static bool TryGetLandsByPos(this BlockPos pos, Helper.Dimension dim, out LandData land) => TryGetLandsByPos(pos.X, pos.Y, pos.Z, dim, out land);
    internal static bool TryGetLandsByPos(this Vec3 pos, Helper.Dimension dim, out LandData land) => TryGetLandsByPos(pos.X, pos.Y, pos.Z, dim, out land);
    internal static bool TryGetLandsByPos(this Vector3 pos, Helper.Dimension dim, out LandData land) => TryGetLandsByPos(pos.X, pos.Y, pos.Z, dim, out land);
    internal static bool TryGetLandsByPos(float x, float y, float z, Helper.Dimension dim, out LandData land)
    {
        List<LandData> lands = GetLandsByAABB(new AABB(x, y, z, x, y, z), dim);
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
    internal static List<LandData> GetLandsByAABB(AABB aabb, Helper.Dimension dim)
    {
        List<LandData> list = new();
        ILiteCollection<LandData> col = Main.DataBase.GetCollection<LandData>("lands");
        IEnumerable<LandData> find = col.Find(e => e.Pos.Intersects(aabb) && e.Dimension == dim);
        list.AddRange(find);
        return list;
    }
    internal static bool HasPermission(Player player, LandData data, string type, string subType) => HasPermission(player.Xuid, data, type, subType);
    internal static bool HasPermission(string xuid, LandData data, string? type, string? subType) => data.Owner == xuid || (type is not null && subType is not null && data.Collaborators.TryGetValue(xuid, out Permissions permissions) && permissions[type][subType]);
}

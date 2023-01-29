using Territory.Type;

namespace Territory.Utils;

internal static class LandHelper
{
    internal static void GetLandsByPos(this BlockPos pos, Helper.Dimension dim) => GetLandsByPos(pos.X, pos.Y, pos.Z, dim);
    internal static void GetLandsByPos(this Vec3 pos, Helper.Dimension dim) => GetLandsByPos(pos.X, pos.Y, pos.Z, dim);
    internal static List<LandData> GetLandsByPos(float x, float y, float z, Helper.Dimension dim) => GetLandsByAABB(new AABB(x, y, z, x, y, z), dim);
    internal static List<LandData> GetLandsByAABB(AABB aabb, Helper.Dimension dim)
    {
        List<LandData> list = new();
        ILiteCollection<LandData> col = Main.DataBase.GetCollection<LandData>("lands");
        IEnumerable<LandData> find = col.Find(e => e.Pos.Intersects(aabb) && e.Dimension == dim);
        list.AddRange(find);
        return list;
    }
    internal static bool HasPermission(Player player, LandData data, string type, string subType) => HasPermission(player.Xuid, data, type, subType);
#nullable enable
    internal static bool HasPermission(string xuid, LandData data, string? type, string? subType) => data.Owner == xuid || (type is not null && subType is not null && data.Collaborators.TryGetValue(xuid, out Permissions permissions) && permissions[type][subType]);
}

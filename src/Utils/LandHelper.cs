using System.Numerics;
using Territory.Type;

namespace Territory.Utils;

internal static class LandHelper
{
    internal static bool TryGetLand(this BlockPos pos, int dim, out LandData land) => TryGetLand(pos.X, pos.Y, pos.Z, dim, out land);
    internal static bool TryGetLand(this Vec3 pos, int dim, out LandData land) => TryGetLand(pos.X, pos.Y, pos.Z, dim, out land);
    internal static bool TryGetLand(float x, float y, float z, float dim, out LandData land)
    {
        List<LandData> lands = new AABB(x, y, z, x, y, z).GetLands(dim);
        if (lands.Count > 1)
        {
            throw new InvalidDataException("Data err0r - Too much lands! xwx");
        }
        if (lands.Count > 0)
        {
            land = lands[0];
            return true;
        }
        land = default;
        return false;
    }
    internal static List<LandData> GetLands(this AABB aabb, float dim)
    {
        ILiteCollection<LandData> col = Main.DataBase.GetCollection<LandData>("lands");
        List<LandData> list = new();
        void Process(IEnumerable<LandData> lands)
        {
            foreach (LandData land in from land in lands where land.Pos.Intersects(aabb) select land)
            {
                if (land.SubLands.Length > 0)
                {
                    Process(land.SubLands); // 递归我的超人
                    continue;
                }
                list.Add(land);
            }
        }
        Process(col.Find(x => x.Dimension == dim));
        return list;
    }
    internal static bool HasPermission(this Player player, LandData data, string type = default) => HasPermission(player.Xuid, data, type);
    internal static bool HasPermission(string xuid, LandData data, string type = default) => data.Owner == xuid || (!string.IsNullOrWhiteSpace(type) && (data.Collaborators.TryGetValue(xuid, out Type.Permission.Player permissions) ? permissions[type] : data.Permissions.Player[type]));
}

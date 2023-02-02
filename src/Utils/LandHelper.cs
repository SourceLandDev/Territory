using System.Diagnostics.CodeAnalysis;
using Territory.Type;

namespace Territory.Utils;

internal static class LandHelper
{
    internal static bool TryGetLand(this Vec3 pos, int dim, [NotNullWhen(true)] out LandData land)
    {
        List<LandData> lands = new AABB(pos, pos).GetLands(dim);
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
    internal static bool HasPermission(this LandData data, string xuid, string type = default) => data.Owner == xuid || (!string.IsNullOrWhiteSpace(type) && (data.Collaborators.TryGetValue(xuid, out Type.Permission.Player permissions) ? permissions[type] : data.Permissions.Player[type]));
    internal static bool IsInOneLand(Vec3 vec1, Vec3 vec2, int dim, [NotNullWhen(true)] out LandData land)
    {
        ILiteCollection<LandData> col = Main.DataBase.GetCollection<LandData>("lands");
        bool Process(IEnumerable<LandData> lands, [NotNullWhen(true)] out LandData landout)
        {
            landout = null;
            foreach (LandData land in from land in lands where land.Pos.Intersects(vec1, vec1) && land.Pos.Intersects(vec2, vec2) select land)
            {
                if (land.SubLands.Length is 0)
                {
                    return true;
                }
                Process(land.SubLands, out landout); // 递归我的超人
                continue;
            }
            return false;
        }
        return Process(col.Find(x => x.Dimension == dim), out land);
    }
}

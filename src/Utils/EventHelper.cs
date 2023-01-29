using Territory.Type;

namespace Territory.Utils;

internal static class EventHelper
{
    internal static bool ProcessPlayerEvent(Player player, BlockPos pos, int dimId, string eventTypeName, bool isCancelled = false) => ProcessPlayerEvent(player, pos.ToVec3(), dimId, eventTypeName, isCancelled);
    internal static bool ProcessPlayerEvent(Player player, Vec3 pos, int dimId, string eventTypeName, bool isCancelled = false)
    {
        if (isCancelled)
        {
            // 被取消了就鱼我无瓜了（
            return true;
        }
        if (!pos.TryGetLandsByPos(dimId, out LandData land))
        {
            // 没领地一律通过
            return true;
        }
        if (!player.HasPermission(land, eventTypeName))
        {
            // 没权限你想干啥
            player.SendText(I18n.Translate(player.LanguageCode, "territory.event.nopermission", new Dictionary<string, string>
            {
                ["land_name"] = land.Name,
                ["action_type"] = I18n.Translate(player.LanguageCode, $"territory.event.player.{eventTypeName.ToLowerInvariant()}")
            }));
            return false;
        }
        return true;
    }
    internal static bool ProcessAnotherEvent(AABB pos, int dimId, string typeNamespace, string eventTypeName, bool isCancelled = false)
    {
        if (isCancelled)
        {
            // 被取消了就鱼我无瓜了（
            return true;
        }
        List<LandData> lands = pos.GetLands(dimId);
        if (lands.Count <= 0)
        {
            // 没领地一律通过
            return true;
        }
        foreach (LandData land in lands)
        {
            if (!land.Permissions[typeNamespace][eventTypeName])
            {
                // 想啊，很想啊（指拦截
                return false;
            }
        }
        return true;
    }
    internal static bool ProcessAnotherEvent(Vec3 pos, int dimId, string typeNamespace, string eventTypeName, bool isCancelled = false) => ProcessAnotherEvent(pos.ToBlockPos(), dimId, typeNamespace, eventTypeName, isCancelled);
    internal static bool ProcessAnotherEvent(BlockPos pos, int dimId, string typeNamespace, string eventTypeName, bool isCancelled = false)
    {
        if (isCancelled)
        {
            // 被取消了就鱼我无瓜了（
            return true;
        }
        if (!pos.TryGetLandsByPos(dimId, out LandData land))
        {
            // 没领地一律通过
            return true;
        }
        if (!land.Permissions[typeNamespace][eventTypeName])
        {
            // 想啊，很想啊（指拦截
            return false;
        }
        return true;
    }
}

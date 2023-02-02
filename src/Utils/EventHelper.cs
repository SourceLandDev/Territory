using Territory.Type;

namespace Territory.Utils;

internal static class EventHelper
{
    internal static bool ProcessPlayerEvent(Player player, Vec3 pos, int dimId, string eventTypeName, bool isCancelled = false)
    {
        if (isCancelled)
        {
            // 被取消了就鱼我无瓜了（
            return default;
        }
        if (!pos.TryGetLand(dimId, out LandData land))
        {
            // 没领地一律通过
            return true;
        }
        if (!land.HasPermission(player.Xuid, eventTypeName))
        {
            // 没权限你想干啥
            player.SendText(Main.i18nHelper[player.LanguageCode].Translate("territory.event.nopermission", new Dictionary<string, string>
            {
                ["land_name"] = land.Name,
                ["action_type"] = Main.i18nHelper[player.LanguageCode][$"territory.event.player.{eventTypeName.ToLowerInvariant()}"]
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
            return default;
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
    internal static bool ProcessAnotherEvent(Vec3 pos, int dimId, string typeNamespace, string eventTypeName, bool isCancelled = false)
    {
        if (!pos.TryGetLand(dimId, out LandData land))
        {
            // 没领地一律通过
            return true;
        }
        return ProcessAnotherEvent(land, typeNamespace, eventTypeName, isCancelled);
    }
    internal static bool ProcessAnotherEvent(LandData land, string typeNamespace, string eventTypeName, bool isCancelled = false)
    {
        if (isCancelled)
        {
            // 被取消了就鱼我无瓜了（
            return default;
        }
        if (!land.Permissions[typeNamespace][eventTypeName])
        {
            // 想啊，很想啊（指拦截
            return false;
        }
        return true;
    }
}

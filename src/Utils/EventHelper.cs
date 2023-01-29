using Territory.Type;

namespace Territory.Utils;

internal static class EventHelper
{
    internal static bool ProcessPlayerEvent(Player player, BlockPos pos, int dimId, string eventTypeName, bool IsCancelled = false) => ProcessPlayerEvent(player, pos.ToVec3(), dimId, eventTypeName, IsCancelled);
    internal static bool ProcessPlayerEvent(Player player, Vec3 pos, int dimId, string eventTypeName, bool IsCancelled = false)
    {
        if (IsCancelled)
        {
            return true;
        }
        if (!LandHelper.TryGetLandsByPos(pos, Helper.GetDimensionFromDimID(dimId), out LandData land))
        {
            return true;
        }
        if (!LandHelper.HasPermission(player, land, "Player", eventTypeName))
        {
            player.SendText(I18n.Translate(player.LanguageCode, "territory.event.nopermission", new Dictionary<string, string>
            {
                ["land_name"] = land.Name,
                ["action_type"] = I18n.Translate(player.LanguageCode, $"territory.event.player.{eventTypeName.ToLowerInvariant()}")
            }));
        }
        return false;
    }
}

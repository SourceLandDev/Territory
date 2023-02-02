using Territory.Type;
namespace Territory.Utils;

internal static class FormHelper
{
    internal static SimpleForm BuildMain(Player player)
    {
        SimpleForm form = new SimpleForm(Main.i18nHelper[player.LanguageCode]["menu.main.title"], Main.i18nHelper[player.LanguageCode]["menu.main.content"])
                              .AddButton(Main.i18nHelper[player.LanguageCode]["menu.main.button.create"], Main.i18nHelper[player.LanguageCode]["menu.main.button.create.image"], ActionHelper.StartCreate);
        if (!LandHelper.TryGetLand(player.Pos, player.DimensionId, out LandData land) || (!player.IsOP && !land.HasPermission(player.Xuid)))
        {
            return form;
        }
        form.AddButton(Main.i18nHelper[player.LanguageCode]["menu.main.button.manage"], Main.i18nHelper[player.LanguageCode]["menu.main.button.manage.image"], (player) => BuildManage(player, land).SendTo(player));
        return form;
    }

    internal static SimpleForm BuildManage(Player player, LandData land)
    {
        if (!player.IsOP && !land.HasPermission(player.Xuid))
        {
            return new(Main.i18nHelper[player.LanguageCode]["menu.manage.title"], Main.i18nHelper[player.LanguageCode]["menu.manage.content.noperm"]);
        }
        SimpleForm form = new(Main.i18nHelper[player.LanguageCode]["menu.manage.title"], Main.i18nHelper[player.LanguageCode]["menu.manage.content"]);
        form.AddButton("");
        return form;
    }
}

using Territory.Type;

namespace Territory.Utils;

internal static class FormHelper
{
    internal static SimpleForm BuildMain(string languageCode, Vec3 pos, int dim, string xuid, bool isOP)
    {
        SimpleForm form = new SimpleForm(Main.i18nHelper[languageCode]["menu.main.title"], Main.i18nHelper[languageCode]["menu.main.content"])
        .AddButton(Main.i18nHelper[languageCode]["menu.main.button.create"], Main.i18nHelper[languageCode]["menu.main.button.create.image"], ActionHelper.StartCreate);
        if (!LandHelper.TryGetLand(pos, dim, out LandData land) || !isOP && !LandHelper.HasPermission(xuid, land))
        {
            return form;
        }
        form.AddButton(Main.i18nHelper[languageCode]["menu.main.button.manage"], Main.i18nHelper[languageCode]["menu.main.button.manage.image"], (player) => BuildManage(player.LanguageCode).SendTo(player));
        return form;
    }

    internal static SimpleForm BuildManage(string languageCode) => new SimpleForm();
}

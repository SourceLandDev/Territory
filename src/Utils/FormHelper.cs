namespace Territory.Utils;

internal static class FormHelper
{
    internal static SimpleForm BuildMain(string langCode, Vec3 pos, int dim)
    {
        SimpleForm form = new SimpleForm(I18nHelper.Translate(langCode, "menu.main.title"), I18nHelper.Translate(langCode, "menu.main.content"))
        .AddButton(I18nHelper.Translate(langCode, "menu.main.button.create"), I18nHelper.Translate(langCode, "menu.main.button.create.image"), ActionHelper.StartCreate);
        if (!LandHelper.TryGetLandsByPos(pos, dim, out _))
        {
            return form;
        }
        form.AddButton(I18nHelper.Translate(langCode, "menu.main.button.manage"), I18nHelper.Translate(langCode, "menu.main.button.manage.image"), (player) => BuildManage(player.LanguageCode).SendTo(player));
        return form;
    }

    internal static SimpleForm BuildManage(string langCode) => new SimpleForm();
}

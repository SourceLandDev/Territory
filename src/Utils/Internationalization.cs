#nullable enable
namespace Territory.Utils;

internal static class I18n
{
    internal static string Translate(string langCode, string key, Dictionary<string, string>? kvs = null)
    {
        string value = Main.LangData[langCode][key];
        if (kvs is null)
        {
            return value;
        }
        foreach ((string k, string v) in kvs)
        {
            value = value.Replace($"%{k}%", v);
        }
        return value;
    }
}

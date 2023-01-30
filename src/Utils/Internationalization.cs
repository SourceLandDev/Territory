namespace Territory.Utils;

internal static class I18n
{
    /// <summary>
    /// 获取翻译
    /// </summary>
    /// <param name="langCode">语言代码</param>
    /// <param name="key">键</param>
    /// <param name="kvs">参数</param>
    /// <returns>翻译完成的信息</returns>
    internal static string Translate(string langCode, string key, Dictionary<string, string> kvs = default)
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

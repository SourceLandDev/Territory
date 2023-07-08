namespace Territory.Utils;

internal class Internationalization
{
    private readonly Dictionary<string, string> _languageData;
    internal Internationalization(Dictionary<string, string> langData)
    {
        _languageData = langData;
    }
    /// <summary>
    /// 获取翻译
    /// </summary>
    /// <param name="key">键</param>
    /// <param name="values">参数</param>
    /// <returns>翻译完成的信息</returns>
    internal string Translate(string key, params object[] values) => !_languageData.TryGetValue(key, out string value)
            ? key
            : string.Format(value, values);
    internal string this[string languageCode] => Translate(languageCode);
}

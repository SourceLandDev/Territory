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
    /// <param name="kvs">参数</param>
    /// <returns>翻译完成的信息</returns>
    internal string Translate(string key, Dictionary<string, string> kvs = default)
    {
        string value = _languageData[key];
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
    internal string this[string languageCode]
    {
        get => Translate(languageCode);
    }
}

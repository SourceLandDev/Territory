namespace Territory.Utils;

internal class I18nHelper
{
    private readonly Dictionary<string, Internationalization> _language = new();
    internal Internationalization GetLanguageData(string languageCode)
    {
        if (!_language.TryGetValue(languageCode, out Internationalization languageData))
        {
            throw new KeyNotFoundException($"{languageCode} not found, please check your language file");
        }
        return languageData;
    }
    internal void AddLanguage(string languageCode, Internationalization languageData)
    {
        if (_language.ContainsKey(languageCode))
        {
            throw new InvalidDataException($"{languageCode} already exist, please check your languange file");
        }
        _language[languageCode] = languageData;
    }
    internal Internationalization this[string languageCode]
    {
        get => GetLanguageData(languageCode);
        set => AddLanguage(languageCode, value);
    }
}

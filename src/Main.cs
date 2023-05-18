using System.Reflection;
using Territory.Functions;
using Territory.Utils;

namespace Territory;
[PluginMain(pluginName)]
public class Main : IPluginInitializer
{
    internal const string pluginName = "Territory";
    public string Introduction => "A high-performance(maybe) territory management system powered by .NET with LiteLoaderBDS";
    public Dictionary<string, string> MetaData => new()
    {
        ["Link to the repository"] = "https://github.com/SourceLandDev/Territory",
        ["Author"] = "Xingmeng(@StarsDream00), Yuanyu Developers",
        ["License"] = "AGPL 3.0",
        ["WARN"] = "You edited it, you FREE it. DO NOT BE EVAL!"   // AGPL 3.0
    };
    public System.Version Version => Assembly.GetExecutingAssembly().GetName().Version;
    internal static LiteDatabase DataBase;
    internal static ConfigHelper Config;
    internal static I18nHelper i18nHelper;
    public void OnInitialize()
    {
        string path = Path.Combine("plugins", pluginName);
        FileHelper.CheckDir(path);

        DataBase = new(Path.Combine(path, "data.db"));

        Config = new(Path.Combine(path, "config.json"));

        i18nHelper = new(Path.Combine(path, "languagePack"));

        EventSystem.SetupPlayer();

        EventSystem.SetupBlock();

        EventSystem.SetupEntity();

        MainCommand.Setup();

        ServerStoppedEvent.Subscribe(ev =>
        {
            DataBase.Dispose();
            return default;
        });
    }
}

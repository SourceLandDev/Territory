using System.Reflection;
using Territory.Functions;
using Territory.Type;
using Territory.Utils;

namespace Territory;
[PluginMain("Territory")]
public class Main : IPluginInitializer
{
    public string Introduction => "A high-performance(maybe) territory management system powered by .NET";
    public Dictionary<string, string> MetaData => new()
    {
        ["Link to the repository"] = "https://github.com/SourceLandDev/Territory",
        ["Author"] = "Xingmeng(@StarsDream00), SourceLandDev",
        ["License"] = "AGPL 3.0",
        ["WARN"] = "You edited it, you FREE it. DO NOT BE EVAL!"   // AGPL 3.0
    };
    public System.Version Version => Assembly.GetExecutingAssembly().GetName().Version;
    internal static LiteDatabase DataBase;
    internal static Config Config;
    internal static I18nHelper i18nHelper;
    public void OnInitialize()
    {
        string path = Path.Combine("plugins", (GetType().GetCustomAttribute(typeof(PluginMainAttribute)) as PluginMainAttribute).Name);

        FileHelper.CheckDir(path);
        DataBase = new(Path.Combine(path, "data.db"));
        Config = JsonSerializer.Deserialize<Config>(FileHelper.CheckFile(Path.Combine(path, "config.json"), JsonSerializer.Serialize(new Config())));

        DirectoryInfo langFileDir = FileHelper.CheckDir(Path.Combine(path, "languagePack"));
        i18nHelper = new();
        foreach (FileInfo file in langFileDir.GetFiles("*.json"))
        {
            i18nHelper[Path.GetFileNameWithoutExtension(file.Name)] = new(JsonSerializer.Deserialize<Dictionary<string, string>>(FileHelper.CheckFile(file.FullName, JsonSerializer.Serialize(new Dictionary<string, string>()))));
        }

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

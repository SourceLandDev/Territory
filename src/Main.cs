﻿using System.Reflection;
using Territory.Funcs;
using Territory.Lang;
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
    internal static Dictionary<string, LangData> LangData;
    internal static LiteDatabase DataBase;
    internal static Config Config;
    public void OnInitialize()
    {
        string path = Path.Combine("plugins", (GetType().GetCustomAttribute(typeof(PluginMainAttribute)) as PluginMainAttribute).Name);

        Helper.CheckDir(path);
        DataBase = new(Path.Combine(path, "data.db"));
        Config = JsonSerializer.Deserialize<Config>(Helper.CheckFile(Path.Combine(path, "config.json"), JsonSerializer.Serialize(new Config())));

        DirectoryInfo langFileDir = Helper.CheckDir(Path.Combine(path, "lang"));
        foreach (FileInfo file in langFileDir.GetFiles("*.json"))
        {
            LangData[file.Name] = JsonSerializer.Deserialize<LangData>(Helper.CheckFile(file.FullName, JsonSerializer.Serialize(new LangData())));
        }

        EventSystem.SetupPlayer();

        EventSystem.SetupBlock();

        EventSystem.SetupEntity();

        Funcs.Command.Setup();

        Exports.Setup();
    }
}

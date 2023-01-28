using LiteLoader.DynamicCommand;

namespace Territory.Funcs;

internal static class Command
{
    internal static void Setup()
    {
        DynamicCommandInstance instance = DynamicCommand.CreateCommand("ter", Main.LangData[Main.Config.DefaultLanguage].CommandDescription, CommandPermissionLevel.Any);
        instance.SetEnum("MainAction", new() { "setup" });
        instance.AddOverload(new List<string>() { "MainAction" });
    }
}

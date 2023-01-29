using LiteLoader.DynamicCommand;
using Territory.Utils;

namespace Territory.Functions;

internal static class MainCommand
{
    internal static void Setup()
    {
        // TODO：命令（暂未设计）
        DynamicCommandInstance instance = DynamicCommand.CreateCommand("ter", I18n.Translate(Thread.CurrentThread.CurrentCulture.Name.Replace('-', '_'), "territory.command.description"), CommandPermissionLevel.Any);
        instance.AddOverload(new List<string>());
        instance.SetCallback((cmd, origin, output, results) => { });
        DynamicCommand.Setup(instance);
    }
}

using LiteLoader.DynamicCommand;
using Territory.Utils;

namespace Territory.Functions;

internal static class MainCommand
{
    internal static void Setup()
    {
        DynamicCommandInstance instance = DynamicCommand.CreateCommand("ter", Main.i18nHelper[Thread.CurrentThread.CurrentCulture.Name.Replace('-', '_')]["territory.command.description"], CommandPermissionLevel.Any);
        instance.AddOverload(new List<string>());
        instance.SetCallback((cmd, origin, output, results) =>
        {
            if (origin.Player is null)
            {
                output.Error("commands.generic.noTargetMatch");
                return;
            }
            FormHelper.BuildMain(origin.Player).SendTo(origin.Player);
        });
        DynamicCommand.Setup(instance);
        ActionHelper.CreationInit();
    }
}

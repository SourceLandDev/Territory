namespace Territory.Funcs;

internal static class EventSystem
{
    // TODO：事件权限检测
    internal static void SetupPlayer()
    {
        ArmorStandChangeEvent.Subscribe(ev =>
        {
            return true;
        });
        Thook.RegisterHook<OnMoveEventHook, OnMoveHookDelegate>();
    }
    internal static void SetupBlock()
    {
    }
    internal static void SetupEntity()
    {
    }
}

namespace Territory.Funcs;

internal delegate void OnMoveHookDelegate(nint @this, nint a2, nint a3, float a4);
[HookSymbol("?onMovePlayerPacketNormal@Player@@MEAAXAEBVVec3@@AEBVVec2@@M@Z")]
internal class OnMoveEventHook : THookBase<OnMoveHookDelegate>
{
    public override OnMoveHookDelegate Hook => (@this, a2, a3, a4) =>
    {
        // TODO：移动权限检测
        throw new NotImplementedException();
    };
}

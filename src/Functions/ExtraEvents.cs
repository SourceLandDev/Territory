namespace Territory.Functions;

internal delegate void ActorMoveEventDelegate(pointer<Actor> @this, nint /* IActorMovementProxy */ a2, Vec3 a3);
[HookSymbol("?_move@Actor@@SAXAEAUIActorMovementProxy@@AEBVVec3@@@Z")]
internal class ActorMoveEventHook : THookBase<ActorMoveEventDelegate>
{
    public override ActorMoveEventDelegate Hook => (@this, a2, a3) =>
    {
        Actor actor = @this.Dereference();
        /// TODO：移动权限检测
        /// 玩家无权限时不可移动，在内部自动移出
        /// 生物无权限时可出不可入
        throw new NotImplementedException();
    };
}


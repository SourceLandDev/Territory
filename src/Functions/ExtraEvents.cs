using Territory.Utils;

namespace Territory.Functions;

internal delegate void ActorMoveEventDelegate(pointer<Actor> @this, /* IActorMovementProxy */ nint a2, /* Vec3 */ Vec3 a3);
[HookSymbol("?_move@Actor@@SAXAEAUIActorMovementProxy@@AEBVVec3@@@Z")]
internal class ActorMoveEventHook : THookBase<ActorMoveEventDelegate>
{
    public override ActorMoveEventDelegate Hook => (@this, a2, a3) =>
    {
        /// TODO：移动权限检测
        /// 玩家无权限时在内部自动移出
        /// 生物无权限时可出不可入
        Actor actor = @this.Dereference();
        if (actor.IsPlayer && !EventHelper.ProcessPlayerEvent(new(@this.Intptr), a3, actor.DimensionId, "Move"))
        {
            return;
        }
        Original(@this, a2, a3);
    };
}


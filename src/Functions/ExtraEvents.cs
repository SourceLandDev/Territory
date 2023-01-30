using Territory.Utils;

namespace Territory.Functions;

internal delegate void ActorMoveEventDelegate(pointer<Actor> @this, Vec3 a2);
[HookSymbol("?move@Actor@@UEAAXAEBVVec3@@@Z")]
internal class ActorMoveEventHook : THookBase<ActorMoveEventDelegate>
{
    public override ActorMoveEventDelegate Hook => (@this, a2) =>
    {
        /// TODO：移动权限检测
        /// 生物无权限时可出（不可入）
        Actor actor = @this.Dereference();
        if (!EventHelper.ProcessAnotherEvent(a2, actor.DimensionId, "Entity", "Move"))
        {
            return;
        }
        Original(@this, a2);
    };
}

internal delegate void PlayerMoveEventDelegate(pointer<Player> @this, Vec3 a2);
[HookSymbol("?move@Player@@UEAAXAEBVVec3@@@Z")]
internal class PlayerMoveEventHook : THookBase<PlayerMoveEventDelegate>
{
    public override PlayerMoveEventDelegate Hook => (@this, a2) =>
    {
        /// TODO：移动权限检测
        /// 玩家无权限时在内部自动移出
        Player player = @this.Dereference();
        if (!EventHelper.ProcessPlayerEvent(player, a2, player.DimensionId, "Move"))
        {
            return;
        }
        Original(@this, a2);
    };
}

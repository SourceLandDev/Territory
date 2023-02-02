using Territory.Utils;

namespace Territory.Functions;

internal delegate void ActorMoveEventDelegate(pointer<Actor> @this, Vec3 a2);
[HookSymbol("?move@Actor@@UEAAXAEBVVec3@@@Z")]
internal class ActorMoveEventHook : THookBase<ActorMoveEventDelegate>
{
    public override ActorMoveEventDelegate Hook => (@this, a2) =>
    {
        // TODO：生物无权限时可出（不可入）
        Actor actor = @this.Dereference();
        if (actor.PlayerOwner is not null && !EventHelper.ProcessPlayerEvent(actor.PlayerOwner, a2, actor.DimensionId, "Move"))
        {
            return;
        }
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
        // TODO：玩家无权限时在内部自动移出
        Player player = @this.Dereference();
        if (a2.TryGetLand(player.DimensionId, out Type.LandData land) && (!player.Pos.TryGetLand(player.DimensionId, out Type.LandData land1) || !land.Equals(land1)))
        {
            ParticleAPI.DrawCuboid(int.MaxValue, true, true, land.Pos, land.Dimension);
        }
        if (!EventHelper.ProcessPlayerEvent(player, a2, player.DimensionId, "Move"))
        {
            return;
        }
        Original(@this, a2);
    };
}

internal delegate void SculkSpreadEventDelegate(/* SculkChargeCursor */ nint @this, /* IBlockWorldGenAPI */ nint a2, pointer<BlockSource> a3, BlockPos a4, /* Random */ nint a5, /* SculkSpreader */ nint a6, bool a7);
[HookSymbol("?update@SculkChargeCursor@@QEAAXAEAVIBlockWorldGenAPI@@PEAVBlockSource@@AEBVBlockPos@@AEAVRandom@@AEAVSculkSpreader@@_N@Z")]
internal class SculkSpreadEventHook : THookBase<SculkSpreadEventDelegate>
{
    public override SculkSpreadEventDelegate Hook => (@this, a2, a3, a4, a5, a6, a7) =>
    {
        if (!EventHelper.ProcessAnotherEvent(a4.ToVec3(), a3.Dereference().DimensionId, "Block", "Spread"))
        {
            return;
        }
        Original(@this, a2, a3, a4, a5, a6, a7);
    };
}

internal delegate void MossSpreadEventDelegate(/* MossBlock */ nint @this, pointer<BlockSource> a2, BlockPos a3, pointer<Actor> a4, /* FertilizerType */int a5);
[HookSymbol("?onFertilized@MossBlock@@UEBA_NAEAVBlockSource@@AEBVBlockPos@@PEAVActor@@W4FertilizerType@@@Z")]
internal class MossSpreadEventHook : THookBase<MossSpreadEventDelegate>
{
    public override MossSpreadEventDelegate Hook => (@this, a2, a3, a4, a5) =>
    {
        BlockSource blockSource = a2.Dereference();
        if (!EventHelper.ProcessAnotherEvent(a3.ToVec3(), blockSource.DimensionId, "Block", "Spread"))
        {
            return;
        }
        Original(@this, a2, a3, a4, a5);
    };
}

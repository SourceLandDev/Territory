using Territory.Utils;

namespace Territory.Functions;

internal static class EventSystem
{
    internal static void SetupPlayer()
    {
        PlayerUseItemOnEvent.Subscribe(ev => EventHelper.ProcessPlayerEvent(ev.Player, ev.ClickPos, ev.BlockInstance.DimensionId, "UseItemOn", ev.IsCancelled));
        PlayerAttackEvent.Subscribe(ev => EventHelper.ProcessPlayerEvent(ev.Player, ev.Target.Pos, ev.Target.DimensionId, "Attack", ev.IsCancelled));
        PlayerAttackBlockEvent.Subscribe(ev => EventHelper.ProcessPlayerEvent(ev.Player, ev.BlockInstance.Position, ev.BlockInstance.DimensionId, "AttackBlock", ev.IsCancelled));
        PlayerPickupItemEvent.Subscribe(ev => EventHelper.ProcessPlayerEvent(ev.Player, ev.ItemEntity.Pos, ev.ItemEntity.DimensionId, "PickupItem", ev.IsCancelled));
        PlayerDropItemEvent.Subscribe(ev => EventHelper.ProcessPlayerEvent(ev.Player, ev.Player.Pos, ev.Player.DimensionId, "DropItem", ev.IsCancelled));   // 需要考虑在外面丢进里面的情况（应该可以通过阻止移动解决）
        PlayerPlaceBlockEvent.Subscribe(ev => EventHelper.ProcessPlayerEvent(ev.Player, ev.BlockInstance.Position, ev.BlockInstance.DimensionId, "PlaceBlock", ev.IsCancelled));
        PlayerDestroyBlockEvent.Subscribe(ev => EventHelper.ProcessPlayerEvent(ev.Player, ev.BlockInstance.Position, ev.BlockInstance.DimensionId, "DestroyBlock", ev.IsCancelled));
        PlayerOpenContainerEvent.Subscribe(ev => EventHelper.ProcessPlayerEvent(ev.Player, ev.BlockInstance.Position, ev.BlockInstance.DimensionId, "OpenContainer", ev.IsCancelled));
        PlayerUseRespawnAnchorEvent.Subscribe(ev => EventHelper.ProcessPlayerEvent(ev.Player, ev.BlockInstance.Position, ev.BlockInstance.DimensionId, "UseRespawnAnchor", ev.IsCancelled));
        PlayerUseFrameBlockEvent.Subscribe(ev => EventHelper.ProcessPlayerEvent(ev.Player, ev.BlockInstance.Position, ev.BlockInstance.DimensionId, "UseFrameBlock", ev.IsCancelled));
        BlockInteractedEvent.Subscribe(ev => EventHelper.ProcessPlayerEvent(ev.Player, ev.BlockInstance.Position, ev.BlockInstance.DimensionId, "InteractBlock", ev.IsCancelled));
        PlayerBedEnterEvent.Subscribe(ev => EventHelper.ProcessPlayerEvent(ev.Player, ev.BlockInstance.Position, ev.BlockInstance.DimensionId, "BedEnter", ev.IsCancelled));
        ArmorStandChangeEvent.Subscribe(ev => EventHelper.ProcessPlayerEvent(ev.Player, ev.ArmorStand.Pos, ev.ArmorStand.DimensionId, "ArmorStandChange", ev.IsCancelled));
    }
    // TODO：事件权限检测
    internal static void SetupBlock()
    {
        BlockChangedEvent.Subscribe(ev =>
        {
            return true;
        });
        BlockExplodedEvent.Subscribe(ev =>
        {
            return true;
        });
        FireSpreadEvent.Subscribe(ev =>
        {
            return true;
        });
        ProjectileHitBlockEvent.Subscribe(ev =>
        {
            return true;
        });
        RedStoneUpdateEvent.Subscribe(ev =>
        {
            return true;
        });
        HopperSearchItemEvent.Subscribe(ev =>
        {
            return true;
        });
        HopperPushOutEvent.Subscribe(ev =>
        {
            return true;
        });
        PistonTryPushEvent.Subscribe(ev =>
        {
            return true;
        });
        PistonPushEvent.Subscribe(ev =>
        {
            return true;
        });
        FarmLandDecayEvent.Subscribe(ev =>
        {
            return true;
        });
        LiquidSpreadEvent.Subscribe(ev =>
        {
            return true;
        });
        CmdBlockExecuteEvent.Subscribe(ev =>
        {
            return true;
        });
        BlockExplodeEvent.Subscribe(ev =>
        {
            return true;
        });
    }
    internal static void SetupEntity()
    {
        EntityTransformEvent.Subscribe(ev =>
        {
            return true;
        });
        EntityExplodeEvent.Subscribe(ev =>
        {
            return true;
        });
        MobHurtEvent.Subscribe(ev =>
        {
            return true;
        });
        MobDieEvent.Subscribe(ev =>
        {
            return true;
        });
        ProjectileHitEntityEvent.Subscribe(ev =>
        {
            return true;
        });
        WitherBossDestroyEvent.Subscribe(ev =>
        {
            return true;
        });
        EntityRideEvent.Subscribe(ev =>
        {
            return true;
        });
        EntityStepOnPressurePlateEvent.Subscribe(ev =>
        {
            return true;
        });
        ProjectileSpawnEvent.Subscribe(ev =>
        {
            return true;
        });
        ProjectileCreatedEvent.Subscribe(ev =>
        {
            return true;
        });
        MobTrySpawnEvent.Subscribe(ev =>
        {
            return true;
        });
        MobSpawnedEvent.Subscribe(ev =>
        {
            return true;
        });
        Thook.RegisterHook<ActorMoveEventHook, ActorMoveEventDelegate>();
    }
}

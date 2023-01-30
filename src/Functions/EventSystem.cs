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
        FarmLandDecayEvent.Subscribe(ev => !ev.Actor.IsPlayer || EventHelper.ProcessPlayerEvent(new(ev.Actor.Intptr), ev.BlockInstance.Position, ev.BlockInstance.DimensionId, "FarmLandDecay", ev.IsCancelled));
        MobHurtEvent.Subscribe(ev => !ev.DamageSource.Entity.IsPlayer || EventHelper.ProcessPlayerEvent(new(ev.DamageSource.Entity.Intptr), ev.Mob.Pos, ev.Mob.DimensionId, "HurtMob", ev.IsCancelled));
        EntityRideEvent.Subscribe(ev => !ev.Rider.IsPlayer || EventHelper.ProcessPlayerEvent(new(ev.Rider.Intptr), ev.Vehicle.Pos, ev.Vehicle.DimensionId, "Ride", ev.IsCancelled));
        EntityStepOnPressurePlateEvent.Subscribe(ev => !ev.Actor.IsPlayer|| EventHelper.ProcessPlayerEvent(new(ev.Actor.Intptr), ev.BlockInstance.Position, ev.BlockInstance.DimensionId, "StepOnPressurePlate", ev.IsCancelled));
        ProjectileSpawnEvent.Subscribe(ev => !ev.Shooter.IsPlayer || EventHelper.ProcessPlayerEvent(new(ev.Shooter.Intptr), ev.Shooter.Pos, ev.Shooter.DimensionId, "ProjectileSpawn", ev.IsCancelled));    // 需要考虑在外面射进里面的情况（应该可以通过阻止移动解决）
    }
    // TODO：事件权限检测
    internal static void SetupBlock()
    {
        FireSpreadEvent.Subscribe(ev => EventHelper.ProcessAnotherEvent(ev.Target, ev.DimensionId, "Block", "FireSpread", ev.IsCancelled));
        HopperSearchItemEvent.Subscribe(ev => EventHelper.ProcessAnotherEvent(ev.isMinecart ? ev.MinecartPos.ToBlockPos() : ev.HopperBlock.Position, ev.DimensionId, "Block", "HopperSearchItem", ev.IsCancelled));
        PistonTryPushEvent.Subscribe(ev => EventHelper.ProcessAnotherEvent(ev.TargetBlockInstance.Position, ev.TargetBlockInstance.DimensionId, "Block", "PistonTryPush", ev.IsCancelled));
        LiquidSpreadEvent.Subscribe(ev => EventHelper.ProcessAnotherEvent(ev.Target, ev.DimensionId, "Block", "LiquidSpread", ev.IsCancelled));
        // BlockExplodeEvent.Subscribe(ev => EventHelper.ProcessAnotherEvent(ev, ev.BlockInstance.DimensionId, "Block", "Explode", ev.IsCancelled));
    }
    internal static void SetupEntity()
    {
        EntityExplodeEvent.Subscribe(ev => EventHelper.ProcessAnotherEvent(ev.Pos, ev.BlockSource.DimensionId, "Entity", "Explode", ev.IsCancelled));
        WitherBossDestroyEvent.Subscribe(ev => EventHelper.ProcessAnotherEvent(ev.DestroyRange, ev.WitherBoss.DimensionId, "Entity", "WitherBossDestroy", ev.IsCancelled));
        Thook.RegisterHook<ActorMoveEventHook, ActorMoveEventDelegate>();
    }
}

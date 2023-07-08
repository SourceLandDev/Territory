using Territory.Utils;

namespace Territory.Functions;

internal static class EventSystem
{
    internal static void SetupPlayer()
    {
        PlayerUseItemOnEvent.Event += e => EventHelper.ProcessPlayerEvent(e.Player, e.ClickPos, e.BlockInstance.DimensionId, "UseItemOn", e.IsCancelled);
        PlayerAttackEvent.Event += e => EventHelper.ProcessPlayerEvent(e.Player, e.Target.Pos, e.Target.DimensionId, "Attack", e.IsCancelled);
        PlayerAttackBlockEvent.Event += e => EventHelper.ProcessPlayerEvent(e.Player, e.BlockInstance.Position, e.BlockInstance.DimensionId, "AttackBlock", e.IsCancelled);
        PlayerPickupItemEvent.Event += e => EventHelper.ProcessPlayerEvent(e.Player, e.ItemEntity.Pos, e.ItemEntity.DimensionId, "PickupItem", e.IsCancelled);
        PlayerDropItemEvent.Event += e => EventHelper.ProcessPlayerEvent(e.Player, e.Player.Pos, e.Player.DimensionId, "DropItem", e.IsCancelled);
        PlayerPlaceBlockEvent.Event += e => EventHelper.ProcessPlayerEvent(e.Player, e.BlockInstance.Position, e.BlockInstance.DimensionId, "PlaceBlock", e.IsCancelled);
        PlayerDestroyBlockEvent.Event += e => EventHelper.ProcessPlayerEvent(e.Player, e.BlockInstance.Position, e.BlockInstance.DimensionId, "DestroyBlock", e.IsCancelled);
        PlayerOpenContainerEvent.Event += e => EventHelper.ProcessPlayerEvent(e.Player, e.BlockInstance.Position, e.BlockInstance.DimensionId, "OpenContainer", e.IsCancelled);
        PlayerUseRespawnAnchorEvent.Event += e => EventHelper.ProcessPlayerEvent(e.Player, e.BlockInstance.Position, e.BlockInstance.DimensionId, "UseRespawnAnchor", e.IsCancelled);
        PlayerUseFrameBlockEvent.Event += e => EventHelper.ProcessPlayerEvent(e.Player, e.BlockInstance.Position, e.BlockInstance.DimensionId, "UseFrameBlock", e.IsCancelled);
        BlockInteractedEvent.Event += e => EventHelper.ProcessPlayerEvent(e.Player, e.BlockInstance.Position, e.BlockInstance.DimensionId, "InteractBlock", e.IsCancelled);
        PlayerBedEnterEvent.Event += e => EventHelper.ProcessPlayerEvent(e.Player, e.BlockInstance.Position, e.BlockInstance.DimensionId, "BedEnter", e.IsCancelled);
        ArmorStandChangeEvent.Event += e => EventHelper.ProcessPlayerEvent(e.Player, e.ArmorStand.Pos, e.ArmorStand.DimensionId, "ArmorStandChange", e.IsCancelled);
        FarmLandDecayEvent.Event += e => !e.Actor.IsPlayer || EventHelper.ProcessPlayerEvent(new(e.Actor.Intptr), e.BlockInstance.Position, e.BlockInstance.DimensionId, "FarmLandDecay", e.IsCancelled);
        MobHurtEvent.Event += e => !e.DamageSource.Entity.IsPlayer || EventHelper.ProcessPlayerEvent(new(e.DamageSource.Entity.Intptr), e.Mob.Pos, e.Mob.DimensionId, "HurtMob", e.IsCancelled);
        EntityRideEvent.Event += e => !e.Rider.IsPlayer || EventHelper.ProcessPlayerEvent(new(e.Rider.Intptr), e.Vehicle.Pos, e.Vehicle.DimensionId, "Ride", e.IsCancelled);
        EntityStepOnPressurePlateEvent.Event += e => !e.Actor.IsPlayer || EventHelper.ProcessPlayerEvent(new(e.Actor.Intptr), e.BlockInstance.Position, e.BlockInstance.DimensionId, "StepOnPressurePlate", e.IsCancelled);
        ProjectileSpawnEvent.Event += e => !e.Shooter.IsPlayer || EventHelper.ProcessPlayerEvent(new(e.Shooter.Intptr), e.Shooter.Pos, e.Shooter.DimensionId, "ProjectileSpawn", e.IsCancelled);
        Thook.RegisterHook<PlayerMoveEventHook, PlayerMoveEventDelegate>();
    }
    internal static void SetupBlock()
    {
        FireSpreadEvent.Event += e => EventHelper.ProcessAnotherEvent(e.Target, e.DimensionId, "Block", "FireSpread", e.IsCancelled);
        HopperSearchItemEvent.Event += e => EventHelper.ProcessAnotherEvent(e.Pos, e.DimensionId, "Block", "HopperSearchItem", e.IsCancelled);
        PistonTryPushEvent.Event += e => EventHelper.ProcessAnotherEvent(e.TargetBlockInstance.Position, e.TargetBlockInstance.DimensionId, "Block", "PistonTryPush", e.IsCancelled);
        LiquidSpreadEvent.Event += e => EventHelper.ProcessAnotherEvent(e.Target, e.DimensionId, "Block", "LiquidSpread", e.IsCancelled);
        BlockExplodeEvent.Event += e =>
        {
            if (!e.Breaking)
            {
                return true;
            }
            e.Breaking = EventHelper.ProcessAnotherEvent(new AABB(e.BlockInstance.Position, e.Radius), e.BlockInstance.DimensionId, "Block", "Explode", e.IsCancelled);
            return true;
        };
        Thook.RegisterHook<SculkSpreadEventHook, SculkSpreadEventDelegate>();
        Thook.RegisterHook<MossSpreadEventHook, MossSpreadEventDelegate>();
    }
    internal static void SetupEntity()
    {
        EntityExplodeEvent.Event += e => EventHelper.ProcessAnotherEvent(e.Pos, e.BlockSource.DimensionId, "Entity", "Explode", e.IsCancelled);
        WitherBossDestroyEvent.Event += e => EventHelper.ProcessAnotherEvent(e.DestroyRange, e.WitherBoss.DimensionId, "Entity", "WitherBossDestroy", e.IsCancelled);
        Thook.RegisterHook<ActorMoveEventHook, ActorMoveEventDelegate>();
    }
}

using Territory.Utils;

namespace Territory.Functions;

internal static class EventSystem
{
    internal static void SetupPlayer()
    {
        PlayerUseItemOnEvent.Subscribe(ev => EventHelper.ProcessPlayerEvent(ev.Player, ev.ClickPos, ev.BlockInstance.DimensionId, "UseItemOn", ev.IsCancelled));
        PlayerAttackEvent.Subscribe(ev => EventHelper.ProcessPlayerEvent(ev.Player, ev.Target.Pos, ev.Target.DimensionId, "Attack", ev.IsCancelled));
        PlayerAttackBlockEvent.Subscribe(ev => EventHelper.ProcessPlayerEvent(ev.Player, ev.BlockInstance.Position.ToVec3(), ev.BlockInstance.DimensionId, "AttackBlock", ev.IsCancelled));
        PlayerPickupItemEvent.Subscribe(ev => EventHelper.ProcessPlayerEvent(ev.Player, ev.ItemEntity.Pos, ev.ItemEntity.DimensionId, "PickupItem", ev.IsCancelled));
        PlayerDropItemEvent.Subscribe(ev => EventHelper.ProcessPlayerEvent(ev.Player, ev.Player.Pos, ev.Player.DimensionId, "DropItem", ev.IsCancelled));
        PlayerPlaceBlockEvent.Subscribe(ev => EventHelper.ProcessPlayerEvent(ev.Player, ev.BlockInstance.Position.ToVec3(), ev.BlockInstance.DimensionId, "PlaceBlock", ev.IsCancelled));
        PlayerDestroyBlockEvent.Subscribe(ev => EventHelper.ProcessPlayerEvent(ev.Player, ev.BlockInstance.Position.ToVec3(), ev.BlockInstance.DimensionId, "DestroyBlock", ev.IsCancelled));
        PlayerOpenContainerEvent.Subscribe(ev => EventHelper.ProcessPlayerEvent(ev.Player, ev.BlockInstance.Position.ToVec3(), ev.BlockInstance.DimensionId, "OpenContainer", ev.IsCancelled));
        PlayerUseRespawnAnchorEvent.Subscribe(ev => EventHelper.ProcessPlayerEvent(ev.Player, ev.BlockInstance.Position.ToVec3(), ev.BlockInstance.DimensionId, "UseRespawnAnchor", ev.IsCancelled));
        PlayerUseFrameBlockEvent.Subscribe(ev => EventHelper.ProcessPlayerEvent(ev.Player, ev.BlockInstance.Position.ToVec3(), ev.BlockInstance.DimensionId, "UseFrameBlock", ev.IsCancelled));
        BlockInteractedEvent.Subscribe(ev => EventHelper.ProcessPlayerEvent(ev.Player, ev.BlockInstance.Position.ToVec3(), ev.BlockInstance.DimensionId, "InteractBlock", ev.IsCancelled));
        PlayerBedEnterEvent.Subscribe(ev => EventHelper.ProcessPlayerEvent(ev.Player, ev.BlockInstance.Position.ToVec3(), ev.BlockInstance.DimensionId, "BedEnter", ev.IsCancelled));
        ArmorStandChangeEvent.Subscribe(ev => EventHelper.ProcessPlayerEvent(ev.Player, ev.ArmorStand.Pos, ev.ArmorStand.DimensionId, "ArmorStandChange", ev.IsCancelled));
        FarmLandDecayEvent.Subscribe(ev => !ev.Actor.IsPlayer || EventHelper.ProcessPlayerEvent(new(ev.Actor.Intptr), ev.BlockInstance.Position.ToVec3(), ev.BlockInstance.DimensionId, "FarmLandDecay", ev.IsCancelled));
        MobHurtEvent.Subscribe(ev => !ev.DamageSource.Entity.IsPlayer || EventHelper.ProcessPlayerEvent(new(ev.DamageSource.Entity.Intptr), ev.Mob.Pos, ev.Mob.DimensionId, "HurtMob", ev.IsCancelled));
        EntityRideEvent.Subscribe(ev => !ev.Rider.IsPlayer || EventHelper.ProcessPlayerEvent(new(ev.Rider.Intptr), ev.Vehicle.Pos, ev.Vehicle.DimensionId, "Ride", ev.IsCancelled));
        EntityStepOnPressurePlateEvent.Subscribe(ev => !ev.Actor.IsPlayer || EventHelper.ProcessPlayerEvent(new(ev.Actor.Intptr), ev.BlockInstance.Position.ToVec3(), ev.BlockInstance.DimensionId, "StepOnPressurePlate", ev.IsCancelled));
        ProjectileSpawnEvent.Subscribe(ev => !ev.Shooter.IsPlayer || EventHelper.ProcessPlayerEvent(new(ev.Shooter.Intptr), ev.Shooter.Pos, ev.Shooter.DimensionId, "ProjectileSpawn", ev.IsCancelled));
        Thook.RegisterHook<PlayerMoveEventHook, PlayerMoveEventDelegate>();
    }
    internal static void SetupBlock()
    {
        FireSpreadEvent.Subscribe(ev => EventHelper.ProcessAnotherEvent(ev.Target.ToVec3(), ev.DimensionId, "Block", "FireSpread", ev.IsCancelled));
        HopperSearchItemEvent.Subscribe(ev => EventHelper.ProcessAnotherEvent(ev.isMinecart ? ev.MinecartPos : ev.HopperBlock.Position.ToVec3(), ev.DimensionId, "Block", "HopperSearchItem", ev.IsCancelled));
        PistonTryPushEvent.Subscribe(ev => EventHelper.ProcessAnotherEvent(ev.TargetBlockInstance.Position.ToVec3(), ev.TargetBlockInstance.DimensionId, "Block", "PistonTryPush", ev.IsCancelled));
        LiquidSpreadEvent.Subscribe(ev => EventHelper.ProcessAnotherEvent(ev.Target.ToVec3(), ev.DimensionId, "Block", "LiquidSpread", ev.IsCancelled));
        BlockExplodeEvent.Subscribe_Ref(ev =>
        {
            if (!ev.Breaking)
            {
                return true;
            }
            ev.Breaking = EventHelper.ProcessAnotherEvent(new AABB(ev.BlockInstance.Position.ToVec3(), ev.Radius), ev.BlockInstance.DimensionId, "Block", "Explode", ev.IsCancelled);
            return true;
        });
        Thook.RegisterHook<SculkSpreadEventHook, SculkSpreadEventDelegate>();
        Thook.RegisterHook<MossSpreadEventHook, MossSpreadEventDelegate>();
    }
    internal static void SetupEntity()
    {
        EntityExplodeEvent.Subscribe(ev => EventHelper.ProcessAnotherEvent(ev.Pos, ev.BlockSource.DimensionId, "Entity", "Explode", ev.IsCancelled));
        WitherBossDestroyEvent.Subscribe(ev => EventHelper.ProcessAnotherEvent(ev.DestroyRange, ev.WitherBoss.DimensionId, "Entity", "WitherBossDestroy", ev.IsCancelled));
        Thook.RegisterHook<ActorMoveEventHook, ActorMoveEventDelegate>();
    }
}

namespace Territory.Funcs;

internal static class EventSystem
{
    // TODO：事件权限检测
    internal static void SetupPlayer()
    {
        PlayerUseItemEvent.Subscribe(ev =>
        {
            return true;
        });
        PlayerUseItemOnEvent.Subscribe(ev =>
        {
            return true;
        });
        PlayerJumpEvent.Subscribe(ev =>
        {
            return true;
        });
        PlayerSneakEvent.Subscribe(ev =>
        {
            return true;
        });
        PlayerAttackEvent.Subscribe(ev =>
        {
            return true;
        });
        PlayerAttackBlockEvent.Subscribe(ev =>
        {
            return true;
        });
        PlayerPickupItemEvent.Subscribe(ev =>
        {
            return true;
        });
        PlayerDropItemEvent.Subscribe(ev =>
        {
            return true;
        });
        PlayerDestroyBlockEvent.Subscribe(ev =>
        {
            return true;
        });
        PlayerPlaceBlockEvent.Subscribe(ev =>
        {
            return true;
        });
        PlayerStartDestroyBlockEvent.Subscribe(ev =>
        {
            return true;
        });
        PlayerOpenContainerEvent.Subscribe(ev =>
        {
            return true;
        });
        PlayerSprintEvent.Subscribe(ev =>
        {
            return true;
        });
        PlayerUseRespawnAnchorEvent.Subscribe(ev =>
        {
            return true;
        });
        PlayerOpenContainerScreenEvent.Subscribe(ev =>
        {
            return true;
        });
        PlayerUseFrameBlockEvent.Subscribe(ev =>
        {
            return true;
        });
        PlayerInteractEntityEvent.Subscribe(ev =>
        {
            return true;
        });
        PlayerBedEnterEvent.Subscribe(ev =>
        {
            return true;
        });
        Thook.RegisterHook<OnMoveEventHook, OnMoveHookDelegate>();
    }
    internal static void SetupBlock()
    {
        BlockInteractedEvent.Subscribe(ev =>
        {
            return true;
        });
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
        ContainerChangeEvent.Subscribe(ev =>
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
        NpcCmdEvent.Subscribe(ev =>
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
        ArmorStandChangeEvent.Subscribe(ev =>
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
    }
}

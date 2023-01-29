namespace Territory.Type.Permission;

internal struct Entity : IPermission
{
    internal bool Explode { get; set; }
    internal bool Hurt { get; set; }
    internal bool ProjectileHit { get; set; }
    internal bool WitherBossDestroy { get; set; }
    internal bool Ride { get; set; }
    internal bool StepOnPressurePlate { get; set; }
    internal bool ProjectileSpawn { get; set; }
    internal bool ProjectileCreated { get; set; }
    internal bool Move { get; set; }
}

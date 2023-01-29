namespace Territory.Type.Permission;

internal class Player : PermissionBase
{
    internal bool UseItemOn { get; set; }
    internal bool Attack { get; set; }
    internal bool AttackBlock { get; set; }
    internal bool PickupItem { get; set; }
    internal bool DropItem { get; set; }
    internal bool PlaceBlock { get; set; }
    internal bool DestroyBlock { get; set; }
    internal bool OpenContainer { get; set; }
    internal bool UseRespawnAnchor { get; set; }
    internal bool UseFrameBlock { get; set; }
    internal bool InteractBlock { get; set; }
    internal bool BedEnter { get; set; }
    internal bool ArmorStandChange { get; set; }
    internal bool FarmLandDecay { get; set; }
    internal bool HurtMob { get; set; }
    internal bool Ride { get; set; }
    internal bool StepOnPressurePlate { get; set; }
    internal bool ProjectileSpawn { get; set; }
    internal bool Move { get; set; }
}

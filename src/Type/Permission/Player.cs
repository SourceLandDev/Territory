namespace Territory.Type.Permission;

internal class Player : PermissionBase
{
    public bool UseItemOn { get; set; }
    public bool Attack { get; set; }
    public bool AttackBlock { get; set; }
    public bool PickupItem { get; set; }
    public bool DropItem { get; set; }
    public bool PlaceBlock { get; set; }
    public bool DestroyBlock { get; set; }
    public bool OpenContainer { get; set; }
    public bool UseRespawnAnchor { get; set; }
    public bool UseFrameBlock { get; set; }
    public bool InteractBlock { get; set; }
    public bool BedEnter { get; set; }
    public bool ArmorStandChange { get; set; }
    public bool FarmLandDecay { get; set; }
    public bool HurtMob { get; set; }
    public bool Ride { get; set; }
    public bool StepOnPressurePlate { get; set; }
    public bool ProjectileSpawn { get; set; }
    public bool Move { get; set; }
}

namespace Territory.Type.Permission;

internal struct Player : IPermission
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
}

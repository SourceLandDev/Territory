namespace Territory.Type.Permission;

internal class Block : PermissionBase
{
    public bool HopperSearchItem { get; set; }
    public bool PistonPush { get; set; }
    public bool Explode { get; set; }
    public bool Spread { get; set; }
}

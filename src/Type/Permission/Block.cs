namespace Territory.Type.Permission;

internal class Block : PermissionBase
{
    internal bool FireSpread { get; set; }
    internal bool HopperSearchItem { get; set; }
    internal bool PistonTryPush { get; set; }
    internal bool LiquidSpread { get; set; }
    internal bool Explode { get; set; }
}

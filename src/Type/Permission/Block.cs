namespace Territory.Type.Permission;

internal class Block : PermissionBase
{
    public bool FireSpread { get; set; }
    public bool HopperSearchItem { get; set; }
    public bool PistonTryPush { get; set; }
    public bool LiquidSpread { get; set; }
    public bool Explode { get; set; }
    public bool Spread { get; set; }
}

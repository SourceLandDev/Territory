namespace Territory.Type.Permission;

internal struct Block : IPermission
{
    internal bool Interacted { get; set; }
    internal bool FireSpread { get; set; }
    internal bool RedStoneUpdate { get; set; }
    internal bool PistonTryPush { get; set; }
    internal bool LiquidSpread { get; set; }
    internal bool Explode { get; set; }
}

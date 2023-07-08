namespace Territory.Type.Permission;

internal class Entity : PermissionBase
{
    public bool Explode { get; set; }
    public bool Destroy { get; set; }
    public bool Move { get; set; }
}

using Territory.Type.Permission;

namespace Territory.Type;

internal struct Permissions
{
    internal PermissionBase this[string i]
    {
        get
        {
            System.Type @this = GetType();
            return (PermissionBase)@this.GetProperty(i).GetValue(@this);
        }
    }
    internal Permission.Block Block { get; set; }
    internal Entity Entity { get; set; }
    internal Permission.Player Player { get; set; }
}

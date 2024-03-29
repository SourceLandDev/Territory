using Territory.Type.Permission;

namespace Territory.Type;

internal class Permissions
{
    internal PermissionBase this[string i]
    {
        get
        {
            System.Type @this = GetType();
            return (PermissionBase)@this.GetProperty(i).GetValue(@this);
        }
    }
    public Permission.Block Block { get; set; } = new();
    public Entity Entity { get; set; } = new();
    public Permission.Player Player { get; set; } = new();
}

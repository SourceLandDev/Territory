namespace Territory.Type.Permission;

internal class PermissionBase
{
    internal bool this[string i]
    {
        get
        {
            System.Type @this = GetType();
            return (bool)@this.GetProperty(i).GetValue(@this);
        }
    }
}

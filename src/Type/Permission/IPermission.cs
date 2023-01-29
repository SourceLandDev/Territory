namespace Territory.Type.Permission;

internal interface IPermission
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

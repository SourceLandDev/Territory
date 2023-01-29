namespace Territory.Type.Permission
{
    internal interface IPermission
    {
        internal bool this[string i]
        {
            get
            {
                var @this = GetType();
                return (bool)@this.GetProperty(i).GetValue(@this);
            }
        }

    }
}

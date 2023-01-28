using Territory.Type.Permission;

namespace Territory.Type;

internal struct Permissions
{
    internal Permission.Block Block { get; set; }
    internal Entity Entity { get; set; }
    internal Permission.Player Player { get; set; }
}

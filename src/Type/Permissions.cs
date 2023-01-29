using Territory.Type.Permission;

namespace Territory.Type;

internal struct Permissions
{
    internal IPermission this[string i] => i.ToUpperInvariant() switch
    {
        "BLOCK" => Block,
        "ENTITY" => Entity,
        "PLAYER" => Player,
        _ => throw new InvalidValueException("Value is not exist in Permissions type")
    };
    internal Permission.Block Block { get; set; }
    internal Entity Entity { get; set; }
    internal Permission.Player Player { get; set; }
}

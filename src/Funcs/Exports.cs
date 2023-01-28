namespace Territory.Funcs;

internal static class Exports
{
    internal static void Setup()
    {
        RemoteCallAPI.ExportAs("Territory", "", () => { });
    }
}

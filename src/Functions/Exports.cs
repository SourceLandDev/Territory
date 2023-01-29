namespace Territory.Functions;

internal static class Exports
{
    internal static void Setup()
    {
        RemoteCallAPI.ExportAs("Territory", "", () => { });
    }
}

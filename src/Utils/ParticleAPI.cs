using LiteLoader.NET.Std;
using System.Runtime.InteropServices;

namespace Territory.Utils;
internal static class ParticleAPI
{
    internal enum Direction
    {
        NegY,
        PosY,
        NegZ,
        PosZ,
        NegX,
        PosX,
    };

    internal enum PointSize
    {
        One = 1 << 0,
        Two = 1 << 1,
        Four = 1 << 2,
        Eight = 1 << 3,
        Sixteen = 1 << 4,
    };

    internal enum NumberType
    {
        Zero,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Eleven,
        Twelve,
        Thirteen,
        Fourteen,
        Fifteen,
        Sixteen,
        A = 'A',
        B = 'B',
        C = 'C',
        D = 'D',
        E = 'E',
        F = 'F',
    };

    internal enum ColorPalette
    {
        Black,
        Indigo,
        Lavender,
        Teal,
        Cocoa,
        Dark,
        Oatmeal,
        White,
        Red,
        Apricot,
        Yellow,
        Green,
        Vatblue,
        Slate,
        Pink,
        Fawn,
    };

    [DllImport("ParticleAPI", EntryPoint = "PTAPI_spawnParticle")]
    internal static extern void SpawnParticle(int displayRadius, Vec3 pos, @string particleName, int dimId);
    [DllImport("ParticleAPI", EntryPoint = "PTAPI_drawPoint")]
    internal static extern void DrawPoint(int displayRadius, Vec3 pos, int dimId, PointSize lineWidth = PointSize.Four, ColorPalette color = ColorPalette.White);
    [DllImport("ParticleAPI", EntryPoint = "PTAPI_drawNumber")]
    internal static extern void DrawNumber(int displayRadius, Vec3 pos, int dimId, NumberType num = NumberType.Zero, ColorPalette color = ColorPalette.White);
    [DllImport("ParticleAPI", EntryPoint = "PTAPI_drawAxialLine")]
    internal static extern void DrawAxialLine(int displayRadius, bool highDetial, bool doubleSide, Vec3 originPoint, char direction, double length, int dimId, ColorPalette color = ColorPalette.White);
    [DllImport("ParticleAPI", EntryPoint = "PTAPI_drawOrientedLine")]
    internal static extern void DrawOrientedLine(int displayRadius, Vec3 start, Vec3 end, int dimId, PointSize lineWidth = PointSize.Four, double minSpacing = 1, int maxParticlesNumber = 64, ColorPalette color = ColorPalette.White);
    [DllImport("ParticleAPI", EntryPoint = "PTAPI_drawCuboid")]
    internal static extern void DrawCuboid(int displayRadius, bool highDetial, bool doubleSide, AABB aabb, int dimId, ColorPalette color = ColorPalette.White);
    [DllImport("ParticleAPI", EntryPoint = "PTAPI_drawCircle")]
    internal static extern void DrawCircle(int displayRadius, Vec3 originPoint, char facing, double radius, int dimId, PointSize lineWidth = PointSize.Four, double minSpacing = 1, int maxParticlesNumber = 64, ColorPalette color = ColorPalette.White);
}

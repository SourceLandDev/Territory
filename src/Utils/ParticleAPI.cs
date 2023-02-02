using LiteLoader.NET.Std;
using System.Runtime.InteropServices;

namespace Territory.Utils;
internal static class ParticleAPI
{
    internal enum Direction : ushort
    {
        NEG_Y = 0,
        POS_Y = 1,
        NEG_Z = 2,
        POS_Z = 3,
        NEG_X = 4,
        POS_X = 5,
    };

    internal enum PointSize : ushort
    {
        PX1 = 1,
        PX2 = 2,
        PX4 = 4,
        PX8 = 8,
        PX16 = 16,
    };

    internal enum NumType : ushort
    {
        NUM0 = 0,
        NUM1 = 1,
        NUM2 = 2,
        NUM3 = 3,
        NUM4 = 4,
        NUM5 = 5,
        NUM6 = 6,
        NUM7 = 7,
        NUM8 = 8,
        NUM9 = 9,
        NUMA = 'A',
        NUMB = 'B',
        NUMC = 'C',
        NUMD = 'D',
        NUME = 'E',
        NUMF = 'F',
        NUM10 = 10,
        NUM11 = 11,
        NUM12 = 12,
        NUM13 = 13,
        NUM14 = 14,
        NUM15 = 15,
        NUM16 = 16,
    };

    internal enum ColorPalette
    {
        BLACK,
        INDIGO,
        LAVENDER,
        TEAL,
        COCOA,
        DARK,
        OATMEAL,
        WHITE,
        RED,
        APRICOT,
        YELLOW,
        GREEN,
        VATBLUE,
        SLATE,
        PINK,
        FAWN,
    };

    [DllImport("ParticleAPI", EntryPoint = "PTAPI_spawnParticle")]
    internal static extern void SpawnParticle(int displayRadius, Vec3 pos, @string particleName, int dimId);
    [DllImport("ParticleAPI", EntryPoint = "PTAPI_drawPoint")]
    internal static extern void DrawPoint(int displayRadius, Vec3 pos, int dimId, PointSize lineWidth = PointSize.PX4, ColorPalette color = ColorPalette.WHITE);
    [DllImport("ParticleAPI", EntryPoint = "PTAPI_drawNumber")]
    internal static extern void DrawNumber(int displayRadius, Vec3 pos, int dimId, NumType num = NumType.NUM0, ColorPalette color = ColorPalette.WHITE);
    [DllImport("ParticleAPI", EntryPoint = "PTAPI_drawAxialLine")]
    internal static extern void DrawAxialLine(int displayRadius, bool highDetial, bool doubleSide, Vec3 originPoint, char direction, double length, int dimId, ColorPalette color = ColorPalette.WHITE);
    [DllImport("ParticleAPI", EntryPoint = "PTAPI_drawOrientedLine")]
    internal static extern void DrawOrientedLine(int displayRadius, Vec3 start, Vec3 end, int dimId, PointSize lineWidth = PointSize.PX4, double minSpacing = 1, int maxParticlesNum = 64, ColorPalette color = ColorPalette.WHITE);
    [DllImport("ParticleAPI", EntryPoint = "PTAPI_drawCuboid")]
    internal static extern void DrawCuboid(int displayRadius, bool highDetial, bool doubleSide, AABB aabb, int dimId, ColorPalette color = ColorPalette.WHITE);
    [DllImport("ParticleAPI", EntryPoint = "PTAPI_drawCircle")]
    internal static extern void DrawCircle(int displayRadius, Vec3 originPoint, char facing, double radius, int dimId, PointSize lineWidth = PointSize.PX4, double minSpacing = 1, int maxParticlesNum = 64, ColorPalette color = ColorPalette.WHITE);
}

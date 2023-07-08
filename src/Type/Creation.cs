namespace Territory.Type;
internal class Creation
{
    internal enum Steps
    {
        Pos1 = 1,
        Pos2,
        Pos3
    }
    internal class Data
    {
        internal Steps Step { get; set; }
        internal Vec3 Pos1 { get; set; }
        internal Vec3 Pos2 { get; set; }
    }
}

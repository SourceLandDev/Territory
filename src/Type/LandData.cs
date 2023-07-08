namespace Territory.Type;

internal class LandData
{
    public long Id { get; set; }
    public AABB Bounding { get; set; }
    public int Dimension { get; set; }
    public string Owner { get; set; }
    public string Name { get; set; }
    public Dictionary<string, Permission.Player> Collaborators { get; set; } = new();
    public Permissions Permissions { get; set; } = new Permissions();
    public long Father { get; set; }
    public uint Price { get; set; }
    public DateTime PurchaseDate { get; set; }
    public TimeSpan Validity { get; set; }
}

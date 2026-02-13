namespace ClickSpace.Messiah.Data
{
    public class DoctrineDef
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Tier { get; set; }
        public string Category { get; set; } = string.Empty;
        public float FaithCost { get; set; }
        public float FundCost { get; set; }
    }
}

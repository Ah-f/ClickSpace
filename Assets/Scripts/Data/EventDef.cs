namespace ClickSpace.Messiah.Data
{
    public class EventDef
    {
        public string Id { get; set; } = string.Empty;
        public string Phase { get; set; } = string.Empty;
        public float BaseWeight { get; set; }
        public string ConditionTag { get; set; } = string.Empty;
        public float RiskFactor { get; set; }
    }
}

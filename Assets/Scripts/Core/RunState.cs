namespace ClickSpace.Messiah.Core
{
    public class RunState
    {
        public string RunId { get; set; } = string.Empty;
        public int Tick { get; set; }
        public int Followers { get; set; }
        public float Faith { get; set; }
        public float Fund { get; set; }
        public float Notoriety { get; set; }
        public float Trust { get; set; }
        public float Stability { get; set; }
        public string MessiahId { get; set; } = "M01";
    }
}

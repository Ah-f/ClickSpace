using System.Collections.Generic;

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
        public List<string> DoctrineIds { get; } = new();
        public float MiracleCharge { get; set; }
        public float MiracleSuccess { get; set; }
        public bool ApocalypseBlocked { get; set; }
        public string EndingType { get; set; } = "Unfinished";
        public string LastEventId { get; set; } = "NONE";
    }
}

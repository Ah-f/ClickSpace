using System.Collections.Generic;

namespace ClickSpace.Messiah.Gameplay
{
    public sealed class DoctrineBonus
    {
        public float InflowMultiplier { get; set; } = 1f;
        public float FaithMultiplier { get; set; } = 1f;
        public float FundMultiplier { get; set; } = 1f;
        public float StabilityDelta { get; set; }
        public float TrustDelta { get; set; }
        public float RiskMultiplier { get; set; } = 1f;
    }

    public static class DoctrineSystem
    {
        public static DoctrineBonus CalculateBonus(IEnumerable<string> doctrineIds)
        {
            var bonus = new DoctrineBonus();

            foreach (var id in doctrineIds)
            {
                switch (id)
                {
                    case "D03":
                        bonus.InflowMultiplier += 0.12f;
                        bonus.TrustDelta -= 0.15f;
                        bonus.RiskMultiplier += 0.08f;
                        break;
                    case "D11":
                        bonus.InflowMultiplier += 0.10f;
                        bonus.FundMultiplier += 0.08f;
                        break;
                    case "D20":
                        bonus.FaithMultiplier += 0.15f;
                        bonus.StabilityDelta += 0.35f;
                        break;
                    case "D21":
                        bonus.TrustDelta += 0.35f;
                        bonus.InflowMultiplier -= 0.05f;
                        break;
                    case "D22":
                        bonus.FundMultiplier += 0.20f;
                        bonus.RiskMultiplier += 0.15f;
                        break;
                }
            }

            return bonus;
        }
    }
}

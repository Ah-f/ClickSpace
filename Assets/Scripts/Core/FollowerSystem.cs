using UnityEngine;

namespace ClickSpace.Messiah.Core
{
    public struct FollowerTickResult
    {
        public int Inflow;
        public int Outflow;
        public int NetFollowers;
    }

    public static class FollowerSystem
    {
        public static FollowerTickResult ApplyFollowerTick(RunState state, int baseInflow, float inflowMultiplier, float outflowMultiplier)
        {
            var inflow = Mathf.Max(0, Mathf.RoundToInt(baseInflow * inflowMultiplier));

            var trustFactor = Mathf.Clamp01(1f - state.Trust / 160f);
            var stabilityFactor = Mathf.Clamp01(1f - state.Stability / 170f);
            var baseChurnRate = 0.003f + trustFactor * 0.02f + stabilityFactor * 0.02f;
            var outflow = Mathf.Max(0, Mathf.RoundToInt(state.Followers * baseChurnRate * outflowMultiplier));

            state.Followers = Mathf.Max(0, state.Followers + inflow - outflow);

            return new FollowerTickResult
            {
                Inflow = inflow,
                Outflow = outflow,
                NetFollowers = inflow - outflow,
            };
        }
    }
}

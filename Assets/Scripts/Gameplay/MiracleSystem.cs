using UnityEngine;
using ClickSpace.Messiah.Core;

namespace ClickSpace.Messiah.Gameplay
{
    public static class MiracleSystem
    {
        public static void BuildCharge(RunState state, float faithGain, float notorietyGain)
        {
            var gain = Mathf.Max(0f, faithGain * 0.35f + notorietyGain * 0.5f);
            state.MiracleCharge = Mathf.Clamp(state.MiracleCharge + gain, 0f, 100f);
        }

        public static void TryAutoCastStabilize(RunState state)
        {
            if (state.MiracleCharge < 100f || state.Stability > 58f) return;

            state.MiracleCharge = 0f;
            state.Stability = Mathf.Clamp(state.Stability + 10f, 0f, 100f);
            state.Trust = Mathf.Clamp(state.Trust + 5f, 0f, 100f);
            state.MiracleSuccess = Mathf.Clamp(state.MiracleSuccess + 8f, 0f, 100f);
            state.ApocalypseBlocked = state.MiracleSuccess >= 60f && state.Stability >= 65f;
            state.LastEventId = "MIRACLE_STABILIZE";
        }
    }
}

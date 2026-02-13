using UnityEngine;

namespace ClickSpace.Messiah.Core
{
    public static class RiskSystem
    {
        public static void ApplyPassiveDrift(RunState state, float trustDelta, float stabilityDelta)
        {
            var growthStress = Mathf.Clamp((state.Followers - 1500) / 5000f, 0f, 0.25f);
            var notorietyStress = Mathf.Clamp(state.Notoriety * 0.0015f, 0f, 0.20f);

            state.Trust = Mathf.Clamp(state.Trust + trustDelta - growthStress * 0.9f, 0f, 100f);
            state.Stability = Mathf.Clamp(state.Stability + stabilityDelta - notorietyStress * 10f, 0f, 100f);
        }
    }
}

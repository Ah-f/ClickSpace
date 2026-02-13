using UnityEngine;

namespace ClickSpace.Messiah.Core
{
    public static class ResourceSystem
    {
        public static void ApplyTickGains(RunState state, float faithDelta, float fundDelta, float notorietyDelta)
        {
            state.Faith = Mathf.Max(0f, state.Faith + faithDelta);
            state.Fund = Mathf.Max(0f, state.Fund + fundDelta);
            state.Notoriety = Mathf.Max(0f, state.Notoriety + notorietyDelta);
        }
    }
}

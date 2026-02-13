using UnityEngine;

namespace ClickSpace.Messiah.Gameplay
{
    public readonly struct EventResolution
    {
        public static EventResolution None => new EventResolution("NONE", 0, 0f, 0f, 0f, 0f, 0f);

        public EventResolution(string eventId, int followerDelta, float faithDelta, float fundDelta, float trustDelta, float stabilityDelta, float notorietyDelta)
        {
            EventId = eventId;
            FollowerDelta = followerDelta;
            FaithDelta = faithDelta;
            FundDelta = fundDelta;
            TrustDelta = trustDelta;
            StabilityDelta = stabilityDelta;
            NotorietyDelta = notorietyDelta;
        }

        public string EventId { get; }
        public int FollowerDelta { get; }
        public float FaithDelta { get; }
        public float FundDelta { get; }
        public float TrustDelta { get; }
        public float StabilityDelta { get; }
        public float NotorietyDelta { get; }
    }

    public static class EventSystem
    {
        public static EventResolution TryResolve(int tick, float trust, float stability, float notoriety)
        {
            if (tick % 15 != 0) return EventResolution.None;

            var roll = Random.value;
            if (roll < 0.25f)
            {
                return new EventResolution("E_WORMHOLE", 160, 18f, 25f, 1.5f, -1f, 6f);
            }

            if (roll < 0.50f)
            {
                return new EventResolution("E_SCANDAL", -90, -8f, -12f, -4.5f, -5.5f, 10f);
            }

            if (roll < 0.75f)
            {
                var trustBoost = trust < 50f ? 4f : 2f;
                return new EventResolution("E_CHARITY", 60, 10f, -8f, trustBoost, 3f, -2f);
            }

            var stabilityPenalty = stability < 45f || notoriety > 80f ? -8f : -3f;
            return new EventResolution("E_RIVAL_ATTACK", -45, -4f, -6f, -2.5f, stabilityPenalty, 5f);
        }
    }
}

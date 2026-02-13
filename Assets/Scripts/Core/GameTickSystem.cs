using UnityEngine;
using ClickSpace.Messiah.Gameplay;

namespace ClickSpace.Messiah.Core
{
    public class GameTickSystem : MonoBehaviour
    {
        [SerializeField] private float tickSeconds = 1.0f;
        [SerializeField] private int baseInflow = 12;
        [SerializeField] private float baseFaithGain = 8f;
        [SerializeField] private float baseFundGain = 10f;

        private float elapsed;

        public RunState State { get; private set; } = new RunState();

        private void Awake()
        {
            if (State.DoctrineIds.Count == 0)
            {
                State.DoctrineIds.Add("D03");
                State.DoctrineIds.Add("D11");
                State.DoctrineIds.Add("D20");
            }

            if (State.Followers == 0)
            {
                State.Followers = 1200;
                State.Faith = 100f;
                State.Fund = 100f;
                State.Trust = 60f;
                State.Stability = 65f;
            }
        }

        private void Update()
        {
            if (State.EndingType != "Unfinished") return;

            elapsed += Time.deltaTime;
            if (elapsed < tickSeconds) return;

            elapsed = 0f;
            TickOnce();
        }

        private void TickOnce()
        {
            State.Tick += 1;

            var messiah = MessiahSystem.GetProfile(State.MessiahId);
            var doctrine = DoctrineSystem.CalculateBonus(State.DoctrineIds);

            var inflowMultiplier = messiah.PropagationMultiplier
                * messiah.CharismaMultiplier
                * doctrine.InflowMultiplier
                * (1f + State.Notoriety * 0.002f);

            var outflowMultiplier = doctrine.RiskMultiplier * Mathf.Max(0.6f, 1f - messiah.StabilityBonus * 0.01f);
            var followerTick = FollowerSystem.ApplyFollowerTick(State, baseInflow, inflowMultiplier, outflowMultiplier);

            var faithGain = baseFaithGain * doctrine.FaithMultiplier + followerTick.NetFollowers * 0.02f;
            var fundGain = baseFundGain * doctrine.FundMultiplier + State.Followers * 0.001f;
            var notorietyGain = Mathf.Clamp(followerTick.Inflow * 0.01f, 0f, 5f);
            ResourceSystem.ApplyTickGains(State, faithGain, fundGain, notorietyGain);

            RiskSystem.ApplyPassiveDrift(State, messiah.TrustBonus + doctrine.TrustDelta, messiah.StabilityBonus + doctrine.StabilityDelta);

            var evt = EventSystem.TryResolve(State.Tick, State.Trust, State.Stability, State.Notoriety);
            if (evt.EventId != EventResolution.None.EventId)
            {
                State.LastEventId = evt.EventId;
                State.Followers = Mathf.Max(0, State.Followers + evt.FollowerDelta);
                State.Faith = Mathf.Max(0f, State.Faith + evt.FaithDelta);
                State.Fund = Mathf.Max(0f, State.Fund + evt.FundDelta);
                State.Trust = Mathf.Clamp(State.Trust + evt.TrustDelta, 0f, 100f);
                State.Stability = Mathf.Clamp(State.Stability + evt.StabilityDelta, 0f, 100f);
                State.Notoriety = Mathf.Max(0f, State.Notoriety + evt.NotorietyDelta);
            }

            MiracleSystem.BuildCharge(State, faithGain, notorietyGain);
            MiracleSystem.TryAutoCastStabilize(State);

            State.EndingType = EndingSystem.ResolveEnding(
                State.Followers,
                State.Trust,
                State.MiracleSuccess,
                State.Stability,
                State.ApocalypseBlocked);
        }
    }
}

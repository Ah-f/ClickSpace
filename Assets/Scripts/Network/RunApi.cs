using System.Threading.Tasks;
using ClickSpace.Messiah.Core;

namespace ClickSpace.Messiah.Network
{
    public class RunApi
    {
        public Task<RunState> StartRunAsync(string scenarioId, string difficulty, string messiahId)
        {
            var state = new RunState
            {
                RunId = "local-run",
                MessiahId = messiahId,
                Followers = 1200,
                Faith = 100f,
                Fund = 100f,
                Trust = 60f,
                Stability = 65f,
                Notoriety = 0f,
                MiracleCharge = 0f,
                MiracleSuccess = 0f,
            };

            state.DoctrineIds.Add("D03");
            state.DoctrineIds.Add("D11");
            state.DoctrineIds.Add("D20");
            return Task.FromResult(state);
        }
    }
}

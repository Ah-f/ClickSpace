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
                Faith = 100,
                Fund = 100,
                Trust = 60,
                Stability = 65
            };

            return Task.FromResult(state);
        }
    }
}

using System.Threading.Tasks;

namespace ClickSpace.Messiah.Network
{
    public class ApiClient
    {
        public Task<string> GetBalanceVersionAsync()
        {
            // TODO: implement HTTP call.
            return Task.FromResult("dev");
        }
    }
}

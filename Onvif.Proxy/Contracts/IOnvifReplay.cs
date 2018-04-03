using System.Threading.Tasks;
using onvif.services;

namespace Onvif.Proxy.Contracts
{
    public interface IOnvifReplay
    {
        Task<string> GetReplayUri(string recordingToken, StreamSetup setup);
        Task<ReplayConfiguration> GetReplayConfiguration();
        Task SetReplayConfiguration(ReplayConfiguration config);
    }
}

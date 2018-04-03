using System.Threading.Tasks;
using onvif.services;

namespace Onvif.Proxy.Contracts.Contract
{
    public interface IOnvifReplay
    {
        Task<string> GetReplayUriAsync(string recordingToken, StreamSetup setup);
        Task<ReplayConfiguration> GetReplayConfigurationAsync();
        Task SetReplayConfigurationAsync(ReplayConfiguration config);


    }
}

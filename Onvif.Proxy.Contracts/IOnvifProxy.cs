using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using onvif.services;
using onvif.utils;
using Onvif.Contracts.Model;
using Onvif.Proxy.Contracts.Contract;

namespace Onvif.Proxy.Contracts
{
    public interface IOnvifProxy : 
        IOnvifProperty,
        IOnvifNetworks, 
        IOnvifEvents, 
        IOnvifDevice, 
        IOnvifVideo, 
        IOnvifAudio,
        IOnvifCertificates, 
        IOnvifSession, 
        IOnvifMaintenance, 
        IOnvifUsers,
        IOnvifProfile,
        IOnvifSystemLog,
        IOnvifAnalytics,
        IOnvifImaging,
        IOnvifAction,
        IOnvifRules,
        IOnvifRelays,
        IOnvifReplay,
        IOnvifReceiver,
        IOnvifRecording,
        IOnvifTime,
        IDisposable
    {
        Task<string> GetStreamUrlAsync(string profileToken, StreamType streamType, Transport transport);
        Task<MediaUri> GetStreamUriAsync(StreamSetup setup, string profileToken);
        void DisposeChannels();
        void DisposeEventChannels();
        Task<System.Xml.Schema.XmlSchemaSet> DownloadSchemesAsync(string[] uris);
        System.Xml.Schema.XmlSchemaSet DownloadSchemes(string[] uris);
        Task<Stream> DownloadStream(Uri uri, string accept);
        Task<Stream> FtpDownload(Uri uri);
        Task<IChannel> GetChannelAsync(string profileToken);
        IChannel GetChannel(string profileToken);
        Task<ChannelDescription[]> GetChannelDescriptions();
        Task<Stream> GetSnapshot(string token);
        Task<SupportedFirmwareUpgradeModes> GetSupportedFirmwareUpgradeModesAsync(string token);
        SupportedFirmwareUpgradeModes GetSupportedFirmwareUpgradeModes(string token);
        Task RestoreSystem(string backUpPath);
        Task<string> UpgradeFirmware(string firmwarePath);
        Task<string> UpgradeFirmware(Uri uri, Stream stream, string contentType, NetworkCredential networkCredential);

        Task<MetadataSettings> GetMetadataSettings(string profToken);
        Task SetMetadataConfigurationAsync(MetadataConfiguration metaCfg);
    }
}

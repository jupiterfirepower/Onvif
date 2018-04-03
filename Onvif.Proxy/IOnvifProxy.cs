using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using onvif.services;
using onvif.utils;
using Onvif.Proxy.Contracts;

namespace Onvif.Proxy
{
    public interface IOnvifProxy : 
        IOnvifProperty,
        IOnvifNetworks, 
        IOnvifEvents, 
        IOnvifDevice, 
        IOnvifVideo, 
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
        IOnvifReceiver,
        IOnvifRecording,
        IDisposable
    {
        void DisposeChannels();

        void DisposeEventChannels();

        Task<System.Xml.Schema.XmlSchemaSet> DownloadSchemes(string[] uris);

        Task<Stream> DownloadStream(Uri uri, string accept);

        Task<Stream> FtpDownload(Uri uri);

        Task<IChannel> GetChannel(string profileToken);

        Task<ChannelDescription[]> GetChannelDescriptions();

        Task<Stream> GetSnapshot(string token);

        Task<SupportedFirmwareUpgradeModes> GetSupportedFirmwareUpgradeModes(string token);

        Task RestoreSystem(string backUpPath);

        Task<string> UpgradeFirmware(string firmwarePath);

        Task<string> UpgradeFirmware(Uri uri, Stream strem, string contentType, NetworkCredential networkCredential);

        Task SetScopes(string[] scopes);

        Task SetMetadataConfiguration(MetadataConfiguration metaCfg);
    }
}

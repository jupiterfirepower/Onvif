using System.Threading.Tasks;
using Akka.Actor;
using onvif.services;
using Onvif.Camera.Client.Model;
using Onvif.Contracts.Messages.Onvif;
using Onvif.Contracts.Messages.Onvif.Ptz;
using Onvif.Contracts.Model;

namespace Onvif.Camera.Client
{
    public partial class OnvifClient
    {
        public async Task<OnvifClientResult<bool>> IsAbsoluteMoveSupportedAsync()
        {
            var result = await _proxyActor.Ask<Container<bool>>(new OnvifPtzIsAbsoluteMoveSupported(_url, _userName, _password));
            return result.Success ? (OnvifClientResult<bool>)new OnvifClientResultData<bool>(result.WorkItem) :
                new OnvifClientResultEmpty<bool>(false);
        }

        public OnvifClientResult<bool> IsAbsoluteMoveSupported()
        {
            return IsAbsoluteMoveSupported(_url, _userName, _password);
        }

        public OnvifClientResult<bool> IsAbsoluteMoveSupported(string url, string userName, string password)
        {
            var result = _proxyActor.Ask<Container<bool>>(new OnvifPtzIsAbsoluteMoveSupported(url, userName, password)).Result;
            return result.Success ? (OnvifClientResult<bool>)new OnvifClientResultData<bool>(result.WorkItem) :
                new OnvifClientResultEmpty<bool>(false);
        }

        public async Task<OnvifClientResult<bool>> IsFixedHomePositionAsync()
        {
            var result = await _proxyActor.Ask<Container<bool>>(new OnvifPtzIsFixedHomePosition(_url, _userName, _password));
            return result.Success ? (OnvifClientResult<bool>)new OnvifClientResultData<bool>(result.WorkItem) :
                new OnvifClientResultEmpty<bool>(false);
        }

        public OnvifClientResult<bool> IsFixedHomePosition()
        {
            return IsFixedHomePosition(_url, _userName, _password);
        }

        public OnvifClientResult<bool> IsFixedHomePosition(string url, string userName, string password)
        {
            var result = _proxyActor.Ask<Container<bool>>(new OnvifPtzIsFixedHomePosition(url, userName, password)).Result;
            return result.Success ? (OnvifClientResult<bool>)new OnvifClientResultData<bool>(result.WorkItem) :
                new OnvifClientResultEmpty<bool>(false);
        }

        public async Task<OnvifClientResult<bool>> IsFixedHomePositionSpecifiedAsync()
        {
            var result = await _proxyActor.Ask<Container<bool>>(new OnvifPtzIsFixedHomePositionSpecified(_url, _userName, _password));
            return result.Success ? (OnvifClientResult<bool>)new OnvifClientResultData<bool>(result.WorkItem) :
                new OnvifClientResultEmpty<bool>(false);
        }

        public OnvifClientResult<bool> IsFixedHomePositionSpecified()
        {
            return IsFixedHomePositionSpecified(_url, _userName, _password);
        }

        public OnvifClientResult<bool> IsFixedHomePositionSpecified(string url, string userName, string password)
        {
            var result = _proxyActor.Ask<Container<bool>>(new OnvifPtzIsFixedHomePositionSpecified(url, userName, password)).Result;
            return result.Success ? (OnvifClientResult<bool>)new OnvifClientResultData<bool>(result.WorkItem) :
                new OnvifClientResultEmpty<bool>(false);
        }

        /// <summary>
        /// Flag RelativeMove method supported
        /// </summary>
        /// <returns>boolean</returns>
        public async Task<OnvifClientResult<bool>> IsRelativeMoveSupportedAsync()
        {
            var result = await _proxyActor.Ask<Container<bool>>(new OnvifPtzIsRelativeMoveSupported(_url, _userName, _password));
            return result.Success ? (OnvifClientResult<bool>)new OnvifClientResultData<bool>(result.WorkItem) :
                new OnvifClientResultEmpty<bool>(false);
        }

        public OnvifClientResult<bool> IsRelativeMoveSupported()
        {
            return IsRelativeMoveSupported(_url, _userName, _password);
        }

        public OnvifClientResult<bool> IsRelativeMoveSupported(string url, string userName, string password)
        {
            var result = _proxyActor.Ask<Container<bool>>(new OnvifPtzIsRelativeMoveSupported(url, userName, password)).Result;
            return result.Success ? (OnvifClientResult<bool>)new OnvifClientResultData<bool>(result.WorkItem) :
                new OnvifClientResultEmpty<bool>(false);
        }

        /// <summary>
        /// Flag ContinuousMove method supported
        /// </summary>
        /// <returns>boolean</returns>
        public async Task<OnvifClientResult<bool>> IsContinuousMoveSupportedAsync()
        {
            var result = await _proxyActor.Ask<Container<bool>>(new OnvifPtzIsContinuousMoveSupported(_url, _userName, _password));
            return result.Success ? (OnvifClientResult<bool>)new OnvifClientResultData<bool>(result.WorkItem) :
                new OnvifClientResultEmpty<bool>(false);
        }

        public OnvifClientResult<bool> IsContinuousMoveSupported()
        {
            return IsContinuousMoveSupported(_url, _userName, _password);
        }

        public OnvifClientResult<bool> IsContinuousMoveSupported(string url, string userName, string password)
        {
            var result = _proxyActor.Ask<Container<bool>>(new OnvifPtzIsContinuousMoveSupported(url, userName, password)).Result;
            return result.Success ? (OnvifClientResult<bool>)new OnvifClientResultData<bool>(result.WorkItem) :
                new OnvifClientResultEmpty<bool>(false);
        }

        /// <summary>
        /// Flag GotoHomePosition, SetHomePosition
        /// </summary>
        /// <returns>boolean</returns>
        public async Task<OnvifClientResult<bool>> IsHomeSupportedAsync()
        {
            var result = await _proxyActor.Ask<Container<bool>>(new OnvifPtzIsHomeSupported(_url, _userName, _password));
            return result.Success ? (OnvifClientResult<bool>)new OnvifClientResultData<bool>(result.WorkItem) :
                new OnvifClientResultEmpty<bool>(false);
        }

        public OnvifClientResult<bool> IsHomeSupported()
        {
            return IsHomeSupported(_url, _userName, _password);
        }

        public OnvifClientResult<bool> IsHomeSupported(string url, string userName, string password)
        {
            var result = _proxyActor.Ask<Container<bool>>(new OnvifPtzIsHomeSupported(url, userName, password)).Result;
            return result.Success ? (OnvifClientResult<bool>)new OnvifClientResultData<bool>(result.WorkItem) :
                new OnvifClientResultEmpty<bool>(false);
        }

        /// <summary>
        /// Add Ptz Configuration
        /// </summary>
        /// <param name="profileToken"></param>
        /// <param name="configToken"></param>
        /// <returns></returns>
        public async Task<OnvifResult> AddPtzConfigurationAsync(string profileToken, string configToken)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifAddPtzConfiguration(_url, _userName, _password, profileToken, configToken));
        }

        public OnvifResult AddPtzConfiguration(string profileToken, string configToken)
        {
            return AddPtzConfiguration(_url, _userName, _password, profileToken, configToken);
        }

        public OnvifResult AddPtzConfiguration(string url, string userName, string password, string profileToken, string configToken)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifAddPtzConfiguration(url, userName, password, profileToken, configToken)).Result;
        }
        /// <summary>
        /// Remove Ptz Configuration
        /// </summary>
        /// <param name="profileToken"></param>
        /// <returns></returns>
        public async Task<OnvifResult> RemovePtzConfigurationAsync(string profileToken)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifRemovePtzConfiguration(_url, _userName, _password, profileToken));
        }

        public OnvifResult RemovePtzConfiguration(string profileToken)
        {
            return RemovePtzConfiguration(_url, _userName, _password, profileToken);
        }

        public OnvifResult RemovePtzConfiguration(string url, string userName, string password, string profileToken)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifRemovePtzConfiguration(url, userName, password, profileToken)).Result;
        }

        /// <summary>
        /// See http://www.onvif.org/ver20/ptz/wsdl/ptz.wsdl
        /// Get the descriptions of the available PTZ Nodes.
        /// A PTZ-capable device may have multiple PTZ Nodes. The PTZ Nodes may represent mechanical PTZ drivers, 
        /// uploaded PTZ drivers or digital PTZ drivers. 
        /// PTZ Nodes are the lowest level entities in the PTZ control API and reflect the supported PTZ capabilities. 
        /// The PTZ Node is referenced either by its name or by its reference token.
        /// </summary>
        /// <returns>PTZNode - optional, unbounded; [PTZNode]
        /// A list of the existing PTZ Nodes on the device.</returns>
        public async Task<OnvifClientResult<PTZNode[]>> GetNodesAsync()
        {
            var result = await _proxyActor.Ask<Container<PTZNode[]>>(new OnvifPtzGetNodes(_url, _userName, _password));
            return result.Success ? (OnvifClientResult<PTZNode[]>)new OnvifClientResultData<PTZNode[]>(result.WorkItem) :
                new OnvifClientResultEmpty<PTZNode[]>(new PTZNode[0]);
        }

        public OnvifClientResult<PTZNode[]> GetNodes()
        {
            return GetNodes(_url, _userName, _password);
        }

        public OnvifClientResult<PTZNode[]> GetNodes(string url, string userName, string password)
        {
            var result = _proxyActor.Ask<Container<PTZNode[]>>(new OnvifPtzGetNodes(url, userName, password)).Result;
            return result.Success ? (OnvifClientResult<PTZNode[]>)new OnvifClientResultData<PTZNode[]>(result.WorkItem) :
                new OnvifClientResultEmpty<PTZNode[]>(new PTZNode[0]);
        }

        /// <summary>
        /// Get a specific PTZ Node identified by a reference token or a name.
        /// </summary>
        /// <param name="nodeToken">
        /// NodeToken [ReferenceToken]
        /// Token of the requested PTZNode.
        /// </param>
        /// <returns>PTZNode [PTZNode] A requested PTZNode.</returns>
        public async Task<OnvifClientResult<PTZNode>> GetNodeAsync(string nodeToken)
        {
            var result = await _proxyActor.Ask<Container<PTZNode>>(new OnvifPtzGetNode(_url, _userName, _password, nodeToken));
            return result.Success ? (OnvifClientResult<PTZNode>)new OnvifClientResultData<PTZNode>(result.WorkItem) :
                new OnvifClientResultEmpty<PTZNode>(new PTZNode());
        }

        public OnvifClientResult<PTZNode> GetNode(string nodeToken)
        {
            return GetNode(_url, _userName, _password, nodeToken);
        }

        public OnvifClientResult<PTZNode> GetNode(string url, string userName, string password, string nodeToken)
        {
            var result = _proxyActor.Ask<Container<PTZNode>>(new OnvifPtzGetNode(url, userName, password, nodeToken)).Result;
            return result.Success ? (OnvifClientResult<PTZNode>)new OnvifClientResultData<PTZNode>(result.WorkItem) :
                new OnvifClientResultEmpty<PTZNode>(new PTZNode());
        }

        /// <summary>
        /// List supported coordinate systems including their range limitations. 
        /// Therefore, the options MAY differ depending on whether the PTZ Configuration is assigned to a Profile 
        /// containing a Video Source Configuration. 
        /// In that case, the options may additionally contain coordinate systems referring to the image coordinate system 
        /// described by the Video Source Configuration. 
        /// If the PTZ Node supports continuous movements, 
        /// it shall return a Timeout Range within which Timeouts are accepted by the PTZ Node.
        /// </summary>
        /// <param name="configurationToken">ConfigurationToken [ReferenceToken]
        /// Token of an existing configuration that the options are intended for.</param>
        /// <returns></returns>
        public async Task<OnvifClientResult<PTZConfiguration>> GetConfigurationAsync(string configurationToken)
        {
            var result = await _proxyActor.Ask<Container<PTZConfiguration>>(new OnvifPtzGetConfiguration(_url, _userName, _password, configurationToken));
            return result.Success ? (OnvifClientResult<PTZConfiguration>)new OnvifClientResultData<PTZConfiguration>(result.WorkItem) :
                new OnvifClientResultEmpty<PTZConfiguration>(new PTZConfiguration());
        }

        public OnvifClientResult<PTZConfiguration> GetConfiguration(string configurationToken)
        {
            return GetConfiguration(_url, _userName, _password, configurationToken);
        }

        public OnvifClientResult<PTZConfiguration> GetConfiguration(string url, string userName, string password, string configurationToken)
        {
            var result = _proxyActor.Ask<Container<PTZConfiguration>>(new OnvifPtzGetConfiguration(url, userName, password, configurationToken)).Result;
            return result.Success ? (OnvifClientResult<PTZConfiguration>)new OnvifClientResultData<PTZConfiguration>(result.WorkItem) :
                new OnvifClientResultEmpty<PTZConfiguration>(new PTZConfiguration());
        }

        /// <summary>
        /// Get all the existing PTZConfigurations from the device.
        /// The default Position/Translation/Velocity Spaces are introduced to allow NVCs sending move requests 
        ///without the need to specify a certain coordinate system. 
        /// The default Speeds are introduced to control the speed of move requests (absolute, relative, preset), 
        /// where no explicit speed has been set.
        /// The allowed pan and tilt range for Pan/Tilt Limits is defined by a two-dimensional space range 
        /// that is mapped to a specific Absolute Pan/Tilt Position Space. 
        /// At least one Pan/Tilt Position Space is required by the PTZNode to support Pan/Tilt limits. 
        /// The limits apply to all supported absolute, relative and continuous Pan/Tilt movements. 
        /// The limits shall be checked within the coordinate system for which the limits have been specified. 
        /// That means that even if movements are specified in a different coordinate system, 
        /// the requested movements shall be transformed to the coordinate system of the limits where the limits can be checked. 
        /// When a relative or continuous movements is specified, which would leave the specified limits, 
        /// the PTZ unit has to move along the specified limits. 
        /// The Zoom Limits have to be interpreted accordingly.
        /// </summary>
        /// <returns>PTZConfiguration - optional, unbounded; [PTZConfiguration]
        /// A list of all existing PTZConfigurations on the device.</returns>
        public async Task<OnvifClientResult<PTZConfiguration[]>> GetConfigurationsAsync()
        {
            var result = await _proxyActor.Ask<Container<PTZConfiguration[]>>(new OnvifPtzGetConfigurations(_url, _userName, _password));
            return result.Success ? (OnvifClientResult<PTZConfiguration[]>)new OnvifClientResultData<PTZConfiguration[]>(result.WorkItem) :
                new OnvifClientResultEmpty<PTZConfiguration[]>(new PTZConfiguration[0]);
        }

        public OnvifClientResult<PTZConfiguration[]> GetConfigurations()
        {
            return GetConfigurations(_url, _userName, _password);
        }

        public OnvifClientResult<PTZConfiguration[]> GetConfigurations(string url, string userName, string password)
        {
            var result = _proxyActor.Ask<Container<PTZConfiguration[]>>(new OnvifPtzGetConfigurations(url, userName, password)).Result;
            return result.Success ? (OnvifClientResult<PTZConfiguration[]>)new OnvifClientResultData<PTZConfiguration[]>(result.WorkItem) :
                new OnvifClientResultEmpty<PTZConfiguration[]>(new PTZConfiguration[0]);
        }
        /// <summary>
        /// Set/update a existing PTZConfiguration on the device.
        /// </summary>
        /// <param name="config">PTZConfiguration [PTZConfiguration]</param>
        /// <param name="forcePersistance">ForcePersistence [boolean]
        /// Flag that makes configuration persistent. Example: User wants the configuration to exist after reboot.</param>
        /// <returns>OnvifResult</returns>
        public async Task<OnvifResult> SetConfigurationAsync(PTZConfiguration config, bool forcePersistance)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifPtzSetConfiguration(_url, _userName, _password, config, forcePersistance));
        }

        public OnvifResult SetConfiguration(PTZConfiguration config, bool forcePersistance)
        {
            return SetConfiguration(_url, _userName, _password, config, forcePersistance);
        }

        public OnvifResult SetConfiguration(string url, string userName, string password, PTZConfiguration config, bool forcePersistance)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifPtzSetConfiguration(url, userName, password, config, forcePersistance)).Result;
        }
        /// <summary>
        /// List supported coordinate systems including their range limitations. 
        /// Therefore, the options MAY differ depending on whether the PTZ Configuration is assigned 
        /// to a Profile containing a Video Source Configuration. 
        /// In that case, the options may additionally contain coordinate systems referring to the image 
        /// coordinate system described by the Video Source Configuration. 
        /// If the PTZ Node supports continuous movements, 
        /// it shall return a Timeout Range within which Timeouts are accepted by the PTZ Node.
        /// </summary>
        /// <param name="configurationToken">ConfigurationToken [ReferenceToken]
        /// Token of an existing configuration that the options are intended for.</param>
        /// <returns>
        /// </returns>
        public async Task<OnvifClientResult<PTZConfigurationOptions>> GetConfigurationsOptionsAsync(string configurationToken)
        {
            var result = await _proxyActor.Ask<Container<PTZConfigurationOptions>>(new OnvifPtzGetConfigurationsOptions(_url, _userName, _password, configurationToken));
            return result.Success ? (OnvifClientResult<PTZConfigurationOptions>)new OnvifClientResultData<PTZConfigurationOptions>(result.WorkItem) :
                new OnvifClientResultEmpty<PTZConfigurationOptions>(new PTZConfigurationOptions());
        }

        public OnvifClientResult<PTZConfigurationOptions> GetConfigurationsOptions(string configurationToken)
        {
            return GetConfigurationsOptions(_url, _userName, _password, configurationToken);
        }

        public OnvifClientResult<PTZConfigurationOptions> GetConfigurationsOptions(string url, string userName, string password, string configurationToken)
        {
            var result = _proxyActor.Ask<Container<PTZConfigurationOptions>>(new OnvifPtzGetConfigurationsOptions(url, userName, password, configurationToken)).Result;
            return result.Success ? (OnvifClientResult<PTZConfigurationOptions>)new OnvifClientResultData<PTZConfigurationOptions>(result.WorkItem) :
                new OnvifClientResultEmpty<PTZConfigurationOptions>(new PTZConfigurationOptions());
        }

        /// <summary>
        /// Operation to send auxiliary commands to the PTZ device mapped by the PTZNode in the selected profile. 
        /// The operation is supported if the AuxiliarySupported element of the PTZNode is true
        /// </summary>
        /// <param name="profileToken">ProfileToken [ReferenceToken]
        /// A reference to the MediaProfile where the operation should take place.</param>
        /// <param name="auxData">AuxiliaryData [AuxiliaryData]
        /// The Auxiliary request data.</param>
        /// <returns></returns>
        public async Task<OnvifClientResult<string>> SendAuxiliaryCommandAsync(string profileToken, string auxData)
        {
            var result = await _proxyActor.Ask<Container<string>>(new OnvifPtzSendAuxiliaryCommand(_url, _userName, _password, profileToken, auxData));
            return result.Success ? (OnvifClientResult<string>)new OnvifClientResultData<string>(result.WorkItem) :
                new OnvifClientResultEmpty<string>(string.Empty);
        }

        public OnvifClientResult<string> SendAuxiliaryCommand(string profileToken, string auxData)
        {
            return SendAuxiliaryCommand(_url, _userName, _password, profileToken, auxData);
        }

        public OnvifClientResult<string> SendAuxiliaryCommand(string url, string userName, string password, string profileToken, string auxData)
        {
            var result = _proxyActor.Ask<Container<string>>(new OnvifPtzSendAuxiliaryCommand(url, userName, password, profileToken, auxData)).Result;
            return result.Success ? (OnvifClientResult<string>)new OnvifClientResultData<string>(result.WorkItem) :
                new OnvifClientResultEmpty<string>(string.Empty);
        }

        /// <summary>
        /// The SetPreset command saves the current device position parameters so that the device 
        /// can move to the saved preset position through the GotoPreset operation. 
        /// In order to create a new preset, the SetPresetRequest contains no PresetToken. 
        /// If creation is successful, the Response contains the PresetToken which uniquely identifies the Preset. 
        /// An existing Preset can be overwritten by specifying the PresetToken of the corresponding Preset. 
        /// In both cases (overwriting or creation) an optional PresetName can be specified. 
        /// The operation fails if the PTZ device is moving during the SetPreset operation. 
        /// The device MAY internally save additional states such as imaging properties 
        /// in the PTZ Preset which then should be recalled in the GotoPreset operation.
        /// </summary>
        /// <param name="profileToken">ProfileToken [ReferenceToken]
        /// A reference to the MediaProfile where the operation should take place.</param>
        /// <param name="presetName">PresetName - optional; [string]
        /// A requested preset name.</param>
        /// <param name="presetToken">PresetToken - optional; [ReferenceToken]
        /// A requested preset token.</param>
        /// <returns>PresetToken [ReferenceToken]
        /// A token to the Preset which has been set.</returns>
        public async Task<OnvifClientResult<string>> SetPresetAsync(string profileToken, string presetName, string presetToken)
        {
            var result = await _proxyActor.Ask<Container<string>>(new OnvifPtzSetPreset(_url, _userName, _password, profileToken, presetName, presetToken));
            return result.Success ? (OnvifClientResult<string>)new OnvifClientResultData<string>(result.WorkItem) :
                new OnvifClientResultEmpty<string>(string.Empty);
        }

        public OnvifClientResult<string> SetPreset(string profileToken, string presetName, string presetToken)
        {
            var result =  _proxyActor.Ask<Container<string>>(new OnvifPtzSetPreset(_url, _userName, _password, profileToken, presetName, presetToken)).Result;
            return SetPreset(_url, _userName, _password, profileToken, presetName, presetToken);
        }

        public OnvifClientResult<string> SetPreset(string url, string userName, string password, string profileToken, string presetName, string presetToken)
        {
            var result = _proxyActor.Ask<Container<string>>(new OnvifPtzSetPreset(url, userName, password, profileToken, presetName, presetToken)).Result;
            return result.Success ? (OnvifClientResult<string>)new OnvifClientResultData<string>(result.WorkItem) :
                new OnvifClientResultEmpty<string>(string.Empty);
        }

        /// <summary>
        /// Operation to request all PTZ presets for the PTZNode in the selected profile. 
        /// The operation is supported if there is support for at least on PTZ preset by the PTZNode.
        /// </summary>
        /// <param name="profileToken">
        /// ProfileToken [ReferenceToken]
        /// A reference to the MediaProfile where the operation should take place.</param>
        /// <returns>
        /// Preset - optional, unbounded; [PTZPreset]
        /// A list of presets which are available for the requested MediaProfile.
        /// Name - optional; [Name]
        /// A list of preset position name.
        /// PTZPosition - optional; [PTZVector]
        /// A list of preset position.
        /// PanTilt - optional; [Vector2D]
        /// Pan and tilt position. The x component corresponds to pan and the y component to tilt.
        /// x - required; [float]
        /// y - required; [float]
        /// space - optional; [anyURI]
        /// Pan/tilt coordinate space selector. The following options are defined:
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/PositionGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/TranslationGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/VelocityGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/GenericSpeedSpace
        /// Zoom - optional; [Vector1D]
        /// A zoom position.
        /// x - required; [float]
        /// space - optional; [anyURI]
        /// Pan/tilt coordinate space selector. The following options are defined:
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/PositionGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/TranslationGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/VelocityGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/GenericSpeedSpace
        /// token [ReferenceToken]
        /// </returns>
        public async Task<OnvifClientResult<PTZPreset[]>> GetPresetsAsync(string profileToken)
        {
            var result = await _proxyActor.Ask<Container<PTZPreset[]>>(new OnvifPtzGetPresets(_url, _userName, _password, profileToken));
            return result.Success ? (OnvifClientResult<PTZPreset[]>)new OnvifClientResultData<PTZPreset[]>(result.WorkItem) :
                new OnvifClientResultEmpty<PTZPreset[]>(new PTZPreset[0]);
        }

        public OnvifClientResult<PTZPreset[]> GetPresets(string profileToken)
        {
            return GetPresets(_url, _userName, _password, profileToken);
        }

        public OnvifClientResult<PTZPreset[]> GetPresets(string url, string userName, string password, string profileToken)
        {
            var result = _proxyActor.Ask<Container<PTZPreset[]>>(new OnvifPtzGetPresets(url, userName, password, profileToken)).Result;
            return result.Success ? (OnvifClientResult<PTZPreset[]>)new OnvifClientResultData<PTZPreset[]>(result.WorkItem) :
                new OnvifClientResultEmpty<PTZPreset[]>(new PTZPreset[0]);
        }

        /// <summary>
        /// Operation to remove a PTZ preset for the Node in the selected profile. 
        /// The operation is supported if the PresetPosition capability exists for teh Node in the selected profile.
        /// </summary>
        /// <param name="profileToken">ProfileToken [ReferenceToken]
        /// A reference to the MediaProfile where the operation should take place.</param>
        /// <param name="presetToken">PresetToken [ReferenceToken]
        /// A requested preset token.</param>
        /// <returns>OnvifResult</returns>
        public async Task<OnvifResult> RemovePresetAsync(string profileToken, string presetToken)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifPtzRemovePreset(_url, _userName, _password, profileToken, presetToken));
        }

        public OnvifResult RemovePreset(string profileToken, string presetToken)
        {
            return RemovePreset(_url, _userName, _password, profileToken, presetToken);
        }

        public OnvifResult RemovePreset(string url, string userName, string password, string profileToken, string presetToken)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifPtzRemovePreset(url, userName, password, profileToken, presetToken)).Result;
        }

        /// <summary>
        /// Operation to go to a saved preset position for the PTZNode in the selected profile. 
        /// The operation is supported if there is support for at least on PTZ preset by the PTZNode.
        /// </summary>
        /// <param name="profileToken">ProfileToken [ReferenceToken]
        /// A reference to the MediaProfile where the operation should take place.</param>
        /// <param name="presetToken">PresetToken [ReferenceToken]
        /// A requested preset token.</param>
        /// <param name="speed">Speed - optional; [PTZSpeed]
        /// A requested speed.The speed parameter can only be specified when Speed Spaces are available for the PTZ Node.
        /// PanTilt - optional; [Vector2D]
        /// Pan and tilt speed. The x component corresponds to pan and the y component to tilt. If omitted in a request, the current (if any) PanTilt movement should not be affected.
        /// x - required; [float]
        /// y - required; [float]
        /// space - optional; [anyURI]
        /// Pan/tilt coordinate space selector. The following options are defined:
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/PositionGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/TranslationGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/VelocityGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/GenericSpeedSpace
        /// Zoom - optional; [Vector1D]
        /// A zoom speed. If omitted in a request, the current (if any) Zoom movement should not be affected.
        /// x - required; [float]
        /// space - optional; [anyURI]
        /// Pan/tilt coordinate space selector. The following options are defined:
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/PositionGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/TranslationGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/VelocityGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/GenericSpeedSpace</param>
        /// <returns>OnvifResult</returns>
        public async Task<OnvifResult> GotoPresetAsync(string profileToken, string presetToken, PTZSpeed speed = null)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifPtzGotoPreset(_url, _userName, _password, profileToken, presetToken, speed));
        }

        public OnvifResult GotoPreset(string profileToken, string presetToken, PTZSpeed speed = null)
        {
            return GotoPreset(_url, _userName, _password, profileToken, presetToken, speed);
        }

        public OnvifResult GotoPreset(string url, string userName, string password, string profileToken, string presetToken, PTZSpeed speed = null)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifPtzGotoPreset(url, userName, password, profileToken, presetToken, speed)).Result;
        }
        /// <summary>
        /// Operation to move the PTZ device to it's "home" position. 
        /// The operation is supported if the HomeSupported element in the PTZNode is true.
        /// </summary>
        /// <param name="profileToken">ProfileToken [ReferenceToken]
        /// A reference to the MediaProfile where the operation should take place.</param>
        /// <param name="speed">Speed - optional; [PTZSpeed]
        /// A requested speed.The speed parameter can only be specified when Speed Spaces are available for the PTZ Node.
        /// PanTilt - optional; [Vector2D]
        /// Pan and tilt speed. The x component corresponds to pan and the y component to tilt. If omitted in a request, the current (if any) PanTilt movement should not be affected.
        /// x - required; [float]
        /// y - required; [float]
        /// space - optional; [anyURI]
        /// Pan/tilt coordinate space selector. The following options are defined:
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/PositionGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/TranslationGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/VelocityGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/GenericSpeedSpace
        /// Zoom - optional; [Vector1D]
        /// A zoom speed. If omitted in a request, the current (if any) Zoom movement should not be affected.
        /// x - required; [float]
        /// space - optional; [anyURI]
        /// Pan/tilt coordinate space selector. The following options are defined:
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/PositionGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/TranslationGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/VelocityGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/GenericSpeedSpace</param>
        /// <returns></returns>
        public async Task<OnvifResult> GotoHomePositionAsync(string profileToken, PTZSpeed speed = null)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifPtzGotoHomePosition(_url, _userName, _password, profileToken, speed));
        }

        public OnvifResult GotoHomePosition(string profileToken, PTZSpeed speed = null)
        {
            return GotoHomePosition(_url, _userName, _password, profileToken, speed);
        }

        public OnvifResult GotoHomePosition(string url, string userName, string password, string profileToken, PTZSpeed speed = null)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifPtzGotoHomePosition(url, userName, password, profileToken, speed)).Result;
        }

        /// <summary>
        /// Operation to save current position as the home position. 
        /// The SetHomePosition command returns with a failure if the “home” position is fixed and cannot be overwritten. 
        /// If the SetHomePosition is successful, it is possible to recall the Home Position with the GotoHomePosition command.
        /// </summary>
        /// <param name="profileToken">ProfileToken [ReferenceToken]
        /// A reference to the MediaProfile where the home position should be set.</param>
        /// <returns>OnvifResult</returns>
        public async Task<OnvifResult> SetHomePositionAsync(string profileToken)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifPtzSetHomePosition(_url, _userName, _password, profileToken));
        }

        public OnvifResult SetHomePosition(string profileToken)
        {
            return SetHomePosition(_url, _userName, _password, profileToken);
        }

        public OnvifResult SetHomePosition(string url, string userName, string password, string profileToken)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifPtzSetHomePosition(url, userName, password, profileToken)).Result;
        }

        /// <summary>
        /// Operation to move pan,tilt or zoom to a absolute destination.
        /// The speed argument is optional. If an x/y speed value is given it is up to the device to either use the x value as absolute 
        /// resoluting speed vector or to map x and y to the component speed. 
        /// If the speed argument is omitted, the default speed set by the PTZConfiguration will be used.
        /// </summary>
        /// <param name="profileToken">
        /// ProfileToken [ReferenceToken] 
        /// A reference to the MediaProfile.
        /// </param>
        /// <param name="position">
        /// A Position vector specifying the absolute target position.
        /// PanTilt - optional; [Vector2D]
        /// Pan and tilt position. The x component corresponds to pan and the y component to tilt.
        /// x - required; [float]
        /// y - required; [float]
        /// space - optional; [anyURI]
        /// Pan/tilt coordinate space selector. The following options are defined:
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/PositionGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/TranslationGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/VelocityGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/GenericSpeedSpace
        /// Zoom - optional; [Vector1D]
        /// A zoom position.
        /// x - required; [float]
        /// space - optional; [anyURI]
        /// Pan/tilt coordinate space selector. The following options are defined:
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/PositionGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/TranslationGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/VelocityGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/GenericSpeedSpace
        ///</param>
        /// <param name="speed">Speed - optional; [PTZSpeed] An optional Speed.
        /// PanTilt - optional; [Vector2D]
        /// Pan and tilt speed. The x component corresponds to pan and the y component to tilt. If omitted in a request, the current (if any) PanTilt movement should not be affected.
        /// x - required; [float]
        /// y - required; [float]
        /// space - optional; [anyURI]
        /// Pan/tilt coordinate space selector. The following options are defined:
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/PositionGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/TranslationGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/VelocityGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/GenericSpeedSpace
        /// Zoom - optional; [Vector1D]
        /// A zoom speed. If omitted in a request, the current (if any) Zoom movement should not be affected.
        /// x - required; [float]
        /// space - optional; [anyURI]
        /// Pan/tilt coordinate space selector. The following options are defined:
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/PositionGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/TranslationGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/VelocityGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/GenericSpeedSpace
        /// </param>
        /// <returns>OnvifResult</returns>
        public async Task<OnvifResult> AbsoluteMoveAsync(string profileToken, PTZVector position, PTZSpeed speed = null)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifPtzAbsoluteMove(_url, _userName, _password, profileToken, position, speed));
        }

        public OnvifResult AbsoluteMove(string profileToken, PTZVector position, PTZSpeed speed = null)
        {
            return AbsoluteMove(_url, _userName, _password, profileToken, position, speed);
        }

        public OnvifResult AbsoluteMove(string url, string userName, string password, string profileToken, PTZVector position, PTZSpeed speed = null)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifPtzAbsoluteMove(url, userName, password, profileToken, position, speed)).Result;
        }

        /// <summary>
        /// Operation for continuous Pan/Tilt and Zoom movements. The operation is supported if the PTZNode supports 
        /// at least one continuous Pan/Tilt or Zoom space. 
        /// If the space argument is omitted, the default space set by the PTZConfiguration will be used.
        /// </summary>
        /// <param name="profileToken">
        /// ProfileToken [ReferenceToken] 
        /// A reference to the MediaProfile.
        /// </param>
        /// <param name="velocity">Velocity [PTZSpeed]
        /// A Velocity vector specifying the velocity of pan, tilt and zoom.
        /// PanTilt - optional; [Vector2D]
        /// Pan and tilt speed. The x component corresponds to pan and the y component to tilt. If omitted in a request, the current (if any) PanTilt movement should not be affected.
        /// x - required; [float]
        /// y - required; [float]
        /// space - optional; [anyURI]
        /// Pan/tilt coordinate space selector. The following options are defined:
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/PositionGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/TranslationGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/VelocityGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/GenericSpeedSpace
        /// Zoom - optional; [Vector1D]
        /// A zoom speed. If omitted in a request, the current (if any) Zoom movement should not be affected.
        /// x - required; [float]
        /// space - optional; [anyURI]
        /// Pan/tilt coordinate space selector. The following options are defined:
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/PositionGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/TranslationGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/VelocityGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/GenericSpeedSpace</param>
        /// <param name="timeout">Timeout - optional; [duration]
        /// An optional Timeout parameter.
        /// </param>
        /// <returns>OnvifResult</returns>
        public async Task<OnvifResult> ContinuousMoveAsync(string profileToken, PTZSpeed velocity, XsDuration timeout = null)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifPtzContinuousMove(_url, _userName, _password, profileToken, velocity, timeout));
        }

        public OnvifResult ContinuousMove(string profileToken, PTZSpeed velocity, XsDuration timeout = null)
        {
            return ContinuousMove(_url, _userName, _password, profileToken, velocity, timeout);
        }

        public OnvifResult ContinuousMove(string url, string userName, string password, string profileToken, PTZSpeed velocity, XsDuration timeout = null)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifPtzContinuousMove(url, userName, password, profileToken, velocity, timeout)).Result;
        }

        /// <summary>
        /// Operation for Relative Pan/Tilt and Zoom Move. The operation is supported if the PTZNode supports at least one relative Pan/Tilt or Zoom space.
        /// The speed argument is optional. If an x/y speed value is given it is up to the device to either use the x value as absolute 
        /// resoluting speed vector or to map x and y to the component speed. 
        /// If the speed argument is omitted, the default speed set by the PTZConfiguration will be used.
        /// </summary>
        /// <param name="profileToken">
        /// ProfileToken [ReferenceToken]
        /// A reference to the MediaProfile.
        /// </param>
        /// <param name="traslation">
        /// Translation [PTZVector]
        /// A positional Translation relative to the current position
        /// PanTilt - optional; [Vector2D]
        /// Pan and tilt position. The x component corresponds to pan and the y component to tilt.
        /// x - required; [float]
        /// y - required; [float]
        /// space - optional; [anyURI]
        /// Pan/tilt coordinate space selector. The following options are defined:
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/PositionGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/TranslationGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/VelocityGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/GenericSpeedSpace
        /// Zoom - optional; [Vector1D]
        /// A zoom position.
        /// x - required; [float]
        /// space - optional; [anyURI]
        /// Pan/tilt coordinate space selector. The following options are defined:
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/PositionGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/TranslationGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/VelocityGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/GenericSpeedSpace
        /// </param>
        /// <param name="speed">
        /// Speed - optional; [PTZSpeed]
        /// An optional Speed parameter.
        /// PanTilt - optional; [Vector2D]
        /// Pan and tilt speed. The x component corresponds to pan and the y component to tilt. If omitted in a request, the current (if any) PanTilt movement should not be affected.
        /// x - required; [float]
        /// y - required; [float]
        /// space - optional; [anyURI]
        /// Pan/tilt coordinate space selector. The following options are defined:
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/PositionGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/TranslationGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/VelocityGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/GenericSpeedSpace
        /// Zoom - optional; [Vector1D]
        /// A zoom speed. If omitted in a request, the current (if any) Zoom movement should not be affected.
        /// x - required; [float]
        /// space - optional; [anyURI]
        /// Pan/tilt coordinate space selector. The following options are defined:
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/PositionGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/TranslationGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/VelocityGenericSpace
        /// http://www.onvif.org/ver10/tptz/PanTiltSpaces/GenericSpeedSpace
        /// </param>
        /// <returns>OnvifResult</returns>
        public async Task<OnvifResult> RelativeMoveAsync(string profileToken, PTZVector traslation, PTZSpeed speed = null)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifPtzRelativeMove(_url, _userName, _password, profileToken, traslation, speed));
        }

        public OnvifResult RelativeMove(string profileToken, PTZVector traslation, PTZSpeed speed = null)
        {
            return RelativeMove(_url, _userName, _password, profileToken, traslation, speed);
        }

        public OnvifResult RelativeMove(string url, string userName, string password, string profileToken, PTZVector traslation, PTZSpeed speed = null)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifPtzRelativeMove(url, userName, password, profileToken, traslation, speed)).Result;
        }

        /// <summary>
        /// Operation to request PTZ status for the Node in the selected profile.
        /// </summary>
        /// <param name="profileToken">ProfileToken [ReferenceToken]
        /// A reference to the MediaProfile where the PTZStatus should be requested.</param>
        /// <returns></returns>
        public async Task<OnvifClientResult<PTZStatus>> GetStatusAsync(string profileToken)
        {
            var result = await _proxyActor.Ask<Container<PTZStatus>>(new OnvifPtzGetStatus(_url, _userName, _password, profileToken));
            return result.Success ? (OnvifClientResult<PTZStatus>)new OnvifClientResultData<PTZStatus>(result.WorkItem) :
                new OnvifClientResultEmpty<PTZStatus>(new PTZStatus());
        }

        public OnvifClientResult<PTZStatus> GetStatus(string profileToken)
        {
            return GetStatus(_url, _userName, _password, profileToken);
        }

        public OnvifClientResult<PTZStatus> GetStatus(string url, string userName, string password, string profileToken)
        {
            var result = _proxyActor.Ask<Container<PTZStatus>>(new OnvifPtzGetStatus(url, userName, password, profileToken)).Result;
            return result.Success ? (OnvifClientResult<PTZStatus>)new OnvifClientResultData<PTZStatus>(result.WorkItem) :
                new OnvifClientResultEmpty<PTZStatus>(new PTZStatus());
        }
        /// <summary>
        /// Operation to stop ongoing pan, tilt and zoom movements of absolute relative and continuous type. 
        /// If no stop argument for pan, tilt or zoom is set, the device will stop all ongoing pan, tilt and zoom movements.
        /// </summary>
        /// <param name="profileToken">ProfileToken [ReferenceToken]
        /// A reference to the MediaProfile that indicate what should be stopped.</param>
        /// <param name="panTilt">PanTilt - optional; [boolean]
        /// Set true when we want to stop ongoing pan and tilt movements.If PanTilt arguments are not present, this command stops these movements.</param>
        /// <param name="zoom">Zoom - optional; [boolean]
        /// Set true when we want to stop ongoing zoom movement.If Zoom arguments are not present, this command stops ongoing zoom movement.</param>
        /// <returns>OnvifResult</returns>
        public async Task<OnvifResult> StopAsync(string profileToken, bool panTilt, bool zoom)
        {
            return await _proxyActor.Ask<OnvifResult>(new OnvifPtzStop(_url, _userName, _password, profileToken, panTilt, zoom));
        }

        public OnvifResult Stop(string profileToken, bool panTilt, bool zoom)
        {
            return Stop(_url, _userName, _password, profileToken, panTilt, zoom);
        }

        public OnvifResult Stop(string url, string userName, string password, string profileToken, bool panTilt, bool zoom)
        {
            return _proxyActor.Ask<OnvifResult>(new OnvifPtzStop(url, userName, password, profileToken, panTilt, zoom)).Result;
        }

        #region Odm Methods
        public async Task<OnvifClientResult<PtzData>> GetPtzDataAsync(string profileToken)
        {
            var result = await _proxyActor.Ask<Container<PtzData>>(new OnvifGetPtzData(_url, _userName, _password, profileToken));
            return result.Success ? (OnvifClientResult<PtzData>)new OnvifClientResultData<PtzData>(result.WorkItem) :
                new OnvifClientResultEmpty<PtzData>(new PtzData());
        }

        public OnvifClientResult<PtzData> GetPtzData(string profileToken)
        {
            return GetPtzData(_url, _userName, _password, profileToken);
        }

        public OnvifClientResult<PtzData> GetPtzData(string url, string userName, string password, string profileToken)
        {
            var result = _proxyActor.Ask<Container<PtzData>>(new OnvifGetPtzData(url, userName, password, profileToken)).Result;
            return result.Success ? (OnvifClientResult<PtzData>)new OnvifClientResultData<PtzData>(result.WorkItem) :
                new OnvifClientResultEmpty<PtzData>(new PtzData());
        }

        public async Task<OnvifClientResult<PTZNode>> LoadPtzNodeAsync(PTZConfiguration cfg)
        {
            var result = await _proxyActor.Ask<Container<PTZNode>>(new OnvifLoadPtzNode(_url, _userName, _password, cfg));
            return result.Success ? (OnvifClientResult<PTZNode>)new OnvifClientResultData<PTZNode>(result.WorkItem) :
                new OnvifClientResultEmpty<PTZNode>(new PTZNode());
        }

        public OnvifClientResult<PTZNode> LoadPtzNode(PTZConfiguration cfg)
        {
            return LoadPtzNode(_url, _userName, _password, cfg);
        }

        public OnvifClientResult<PTZNode> LoadPtzNode(string url, string userName, string password, PTZConfiguration cfg)
        {
            var result = _proxyActor.Ask<Container<PTZNode>>(new OnvifLoadPtzNode(url, userName, password, cfg)).Result;
            return result.Success ? (OnvifClientResult<PTZNode>)new OnvifClientResultData<PTZNode>(result.WorkItem) :
                new OnvifClientResultEmpty<PTZNode>(new PTZNode());
        }

        public async Task<OnvifClientResult<PTZStatus>> LoadPtzStatusAsync(string profileToken)
        {
            var result = await _proxyActor.Ask<Container<PTZStatus>>(new OnvifLoadPtzStatus(_url, _userName, _password, profileToken));
            return result.Success ? (OnvifClientResult<PTZStatus>)new OnvifClientResultData<PTZStatus>(result.WorkItem) :
                new OnvifClientResultEmpty<PTZStatus>(new PTZStatus());
        }

        public OnvifClientResult<PTZStatus> LoadPtzStatus(string profileToken)
        {
            return LoadPtzStatus(_url, _userName, _password, profileToken);
        }

        public OnvifClientResult<PTZStatus> LoadPtzStatus(string url, string userName, string password, string profileToken)
        {
            var result = _proxyActor.Ask<Container<PTZStatus>>(new OnvifLoadPtzStatus(url, userName, password, profileToken)).Result;
            return result.Success ? (OnvifClientResult<PTZStatus>)new OnvifClientResultData<PTZStatus>(result.WorkItem) :
                new OnvifClientResultEmpty<PTZStatus>(new PTZStatus());
        }

        public async Task<OnvifClientResult<PTZNode>> CreateStandartPtzNodeAsync(string nodeToken)
        {
            var result = await _proxyActor.Ask<Container<PTZNode>>(new OnvifCreateStandartPtzNode(_url, _userName, _password, nodeToken));
            return result.Success ? (OnvifClientResult<PTZNode>)new OnvifClientResultData<PTZNode>(result.WorkItem) :
                new OnvifClientResultEmpty<PTZNode>(new PTZNode());
        }

        public OnvifClientResult<PTZNode> CreateStandartPtzNode(string nodeToken)
        {
            return CreateStandartPtzNode(_url, _userName, _password, nodeToken);
        }

        public OnvifClientResult<PTZNode> CreateStandartPtzNode(string url, string userName, string password, string nodeToken)
        {
            var result = _proxyActor.Ask<Container<PTZNode>>(new OnvifCreateStandartPtzNode(url, userName, password, nodeToken)).Result;
            return result.Success ? (OnvifClientResult<PTZNode>)new OnvifClientResultData<PTZNode>(result.WorkItem) :
                new OnvifClientResultEmpty<PTZNode>(new PTZNode());
        }
        #endregion
    }
}

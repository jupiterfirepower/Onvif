﻿namespace Onvif.Contracts.Messages.Onvif.Ptz
{
    public class OnvifPtzGetPresets : OnvifBase
    {
        public string ProfileToken { get; private set; }

        public OnvifPtzGetPresets(string uri, string userName, string password, string profileToken)
            : base(uri, userName, password)
        {
            ProfileToken = profileToken;
        }
    }
}

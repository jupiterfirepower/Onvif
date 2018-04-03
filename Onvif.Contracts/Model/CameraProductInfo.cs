using System;

namespace Onvif.Contracts.Model
{
    public class CameraProductInfo
    {
        public string Model { get; private set; }
        public string FirmwareVersion { get; private set; }

        public CameraProductInfo(string model, string firmwareVersion)
        {
            Model = model;
            FirmwareVersion = firmwareVersion;
        }

        public string Manufacturer
        {
            get
            {
                var modelData = Model != null
                    ? Model.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    : new string[0];
                return  modelData.Length > 1 ?  modelData[0] : string.Empty;
            }
        }

        public string BrandModel
        {
            get
            {
                var modelData = Model != null
                    ? Model.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    : new string[0];
                return modelData.Length > 1 ? modelData[1] : string.Empty;
            }
        }
    }
}

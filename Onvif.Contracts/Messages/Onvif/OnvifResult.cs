namespace Onvif.Contracts.Messages.Onvif
{
    public class OnvifResult
    {
        public string ErrMessage { get; set; }
        public bool Result { get; set; }

        public OnvifResult(bool result, string err="")
        {
            Result = result && string.IsNullOrEmpty(err.Trim());
            ErrMessage = err;
        }

        public OnvifResult(string err = ""): this(string.IsNullOrEmpty(err.Trim()), err)
        {
        }

        public OnvifResult(): this(false)
        {
        }

        public static OnvifResult Success
        {
            get
            {
                return new OnvifResult(true);
            }
        }

        public static OnvifResult Failed
        {
            get
            {
                return new OnvifResult(false); 
            }
        }
    }
}

using System;

namespace Onvif.Contracts.Messages
{
    public class Error
    {
        public string Mesage { get; private set; }

        public Exception Exception { get; private set; }

        public int ErrCode { get; private set; }

        public Error(string mesage, Exception ex, int errCode)
        {
            Mesage = mesage;
            Exception = ex;
            ErrCode = errCode;
        }

        public Error(string mesage, Exception ex) : this(mesage,ex, -1)
        {
        }

        public Error(string mesage)
            : this(mesage, null, -1)
        {
        }

        public Error()
            : this(string.Empty, null, -1)
        {
        }
    }
}

namespace Onvif.Contracts.Model
{
    public class ModelBase
    {
        public bool Success { get; set; }
        public string Error { get; set; }

        public ModelBase(bool result)
        {
            Success = result;
        }

        public ModelBase(string error)
            : this(string.IsNullOrEmpty(error))
        {
            Error = error;
        }

        public ModelBase(): this(false)
        {
        }
    }
}

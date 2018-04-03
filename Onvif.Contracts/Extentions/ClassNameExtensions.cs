namespace Onvif.Contracts.Extentions
{
    public static class ClassNameExtensions
    {
        public static string NameOf(this object o)
        {
            return o.GetType().Name;
        }
    }
}

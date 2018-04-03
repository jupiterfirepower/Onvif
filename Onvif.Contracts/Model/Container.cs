namespace Onvif.Contracts.Model
{
    public class Container<T>: ModelBase
    {
        public T WorkItem { get; set; }

        public Container(): base(false)
        {
        }

        public Container(bool success): base(success)
        {
        }
    }
}

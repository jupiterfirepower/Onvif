namespace Onvif.Camera.Client.Model
{
    public abstract class OnvifClientResult<T>
    {
        private readonly T _resultData;

        public T ResultData { get { return _resultData; }}

        public abstract bool IsEmpty { get; }

        protected OnvifClientResult(T data) 
        {
            _resultData = data;
            if (!typeof(T).IsEnum)
            {
                if (data == null)
                {
                    _resultData = default(T);
                }
            }
        }
    }

    public sealed class OnvifClientResultEmpty<T> : OnvifClientResult<T>
    {
        public override bool IsEmpty { get { return true; } }

        public OnvifClientResultEmpty(T data) : base(data)
        {
        }
    }

    public sealed class OnvifClientResultData<T> : OnvifClientResult<T>
    {
        private readonly bool _result;

        public override bool IsEmpty { get { return !typeof(T).IsEnum && !_result; } }

        public OnvifClientResultData(T data) : base(data)
        {
            _result = !typeof(T).IsEnum && data != null;
        }
    }
}

namespace NoName.Signals
{
    public abstract class AbstractSignal : ISignal
    {
        protected string _hash;

        public string Hash
        {
            get
            {
                if (string.IsNullOrEmpty(_hash))
                {
                    _hash = GetType().ToString();
                }

                return _hash;
            }
        }
    }
}
namespace NoName.Signals
{
    public interface ISignalsProvider
    {
        public T Get<T>() where T : ISignal, new();
    }
}
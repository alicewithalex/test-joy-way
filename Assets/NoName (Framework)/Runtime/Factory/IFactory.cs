namespace NoName.Factory
{
    public interface IFactory
    {
        TValue Create<TKey, TValue>(TKey key) where TKey : System.Enum where TValue : class;
    }
}
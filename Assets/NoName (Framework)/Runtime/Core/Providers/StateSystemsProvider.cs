
namespace NoName.Providers
{
    public abstract class StateSystemsProvider<T> : AbstractStateSystemsProvider where T : Data.StateData
    {
        public override System.Type DataType => typeof(T);
    }
}
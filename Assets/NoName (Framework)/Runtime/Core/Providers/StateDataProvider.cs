
namespace NoName.Providers
{
    public abstract class StateDataProvider<T> : AbstractStateDataProvider where T : Data.StateData, new()
    {
        [UnityEngine.SerializeField] private Enums.State _state;

        public override Enums.State State => _state;

        public override Data.StateData GetData(IContainer container)
        {
            T stateData = new T();

            Process(stateData, container);

            return stateData;
        }

        protected abstract void Process(T stateData, IContainer container);
    }
}
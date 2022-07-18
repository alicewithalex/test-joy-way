
namespace NoName.Providers
{
    public abstract class AbstractStateSystemsProvider : UnityEngine.MonoBehaviour, Interfaces.IStateSystemProvider
    {
        [UnityEngine.SerializeField] private Enums.State _state;

        public Enums.State State => _state;

        public abstract System.Type DataType { get; }

        public Systems.StateSystems GetStateSystems(IContainer container)
        {
            if (_state.Equals(Enums.State.None)) return null;

            Systems.StateSystems systems = new Systems.StateSystems(_state);
            Process(systems, container);

            return systems;
        }

        protected abstract void Process(Systems.StateSystems systems, IContainer container);
    }
}
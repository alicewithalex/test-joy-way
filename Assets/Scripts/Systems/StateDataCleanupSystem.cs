using NoName.Data;
using NoName.Injection;
using NoName.Systems;

namespace alicewithalex.Systems
{
    public class StateDataCleanupSystem<T> : IStateUpdateSystem where T : StateData
    {
        [Inject] private readonly T _data;

        public void StateUpdate() => _data.Clean();
    }
}
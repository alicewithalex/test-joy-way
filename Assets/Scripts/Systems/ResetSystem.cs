using NoName.Data;
using NoName.Injection;
using NoName.Systems;
using UnityEngine;

namespace alicewithalex.Systems
{
    public class ResetSystem<T> : IStateUpdateSystem where T : StateData
    {
        [Inject] private readonly T _data;

        private readonly KeyCode _resetKey;

        public ResetSystem(KeyCode resetKey)
        {
            _resetKey = resetKey;
        }

        public void StateUpdate()
        {
            if (Input.GetKeyDown(_resetKey)) Reset(_data);
        }

        private void Reset(T stateData) => stateData.Resetables.ForEach(x => x.OnReset());
    }
}
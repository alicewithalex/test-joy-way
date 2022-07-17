using alicewithalex.Data;
using NoName.Injection;
using NoName.Systems;
using UnityEngine;

namespace alicewithalex.Systems
{
    public class PlayerObtainSystem : IStateUpdateSystem
    {
        [Inject] private readonly GameStateData _stateData;

        public void StateUpdate()
        {
            if (_stateData.Player is null) return;

            if (Physics.Raycast(_stateData.Player.LookRay, out var hit, _stateData.PickupConfig.PickupDistance,
                _stateData.PickupConfig.PickupLayer, QueryTriggerInteraction.Collide))
            {
                if (_stateData.Player.LookAt != null)
                {
                    _stateData.Player.LookAt.Obtainable = false;
                }

                _stateData.Player.LookAt = _stateData.Pickables[hit.transform];
            }

            foreach (var pickable in _stateData.Pickables.Values)
            {
                if (_stateData.Player.LookAt != null && _stateData.Player.LookAt.Equals(pickable)) continue;

                pickable.Obtainable = false;
            }
        }
    }
}
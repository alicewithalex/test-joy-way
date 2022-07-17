using alicewithalex.Data;
using NoName.Injection;
using NoName.Systems;
using UnityEngine;

namespace alicewithalex.Systems
{
    public class PlayerItemTargetSystem : IStateUpdateSystem
    {
        [Inject] private readonly GameStateData _stateData;

        public void StateUpdate()
        {
            if (_stateData.Player is null) return;

            if (Physics.Raycast(_stateData.Player.LookRay, out var hit, _stateData.PickupConfig.PickupDistance,
                _stateData.PickupConfig.PickupLayer, QueryTriggerInteraction.Collide))
            {
                _stateData.Player.LookAt = _stateData.Pickables[hit.transform];
            }
            else
            {
                if (_stateData.Player.LookAt != null)
                {
                    _stateData.Player.LookAt = null;
                }
            }
        }
    }
}
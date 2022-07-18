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

            if (Physics.Raycast(new Ray(_stateData.Camera.transform.position,_stateData.Camera.transform.forward),
                out var hit, _stateData.PickupConfig.PickupDistance,
                _stateData.PickupConfig.PickupLayer, QueryTriggerInteraction.Collide))
            {
                _stateData.Player.LookingAt = _stateData.Pickables[hit.transform];
            }
            else
            {
                if (_stateData.Player.LookingAt != null)
                {
                    _stateData.Player.LookingAt = null;
                }
            }
        }
    }
}
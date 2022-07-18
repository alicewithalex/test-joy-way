using alicewithalex.Data;
using NoName.Injection;
using NoName.Systems;
using UnityEngine;

namespace alicewithalex.Systems
{
    public class PlayerPickupSystem : IStateUpdateSystem
    {
        [Inject] private readonly GameStateData _stateData;

        public void StateUpdate()
        {
            if (_stateData.Player is null || _stateData.Player.LookingAt == null) return;

            if (_stateData.Input.LeftHandPressed)
            {
                if (_stateData.Inventory.Add(SlotType.LeftHand, _stateData.Player.LookingAt))
                {
                    _stateData.Player.LookingAt.Hide();
                    _stateData.Player.LookingAt = null;
                }
            }

            if (_stateData.Input.RightHandPressed)
            {
                if (_stateData.Inventory.Add(SlotType.RightHand, _stateData.Player.LookingAt))
                {
                    _stateData.Player.LookingAt.Hide();
                    _stateData.Player.LookingAt = null;
                }
            }
        }
    }
}
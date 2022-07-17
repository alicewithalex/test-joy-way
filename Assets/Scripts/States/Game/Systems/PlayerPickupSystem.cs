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
            if (_stateData.Player is null || _stateData.Player.LookAt == null) return;

            if (_stateData.Input.LeftHandPressed)
            {
                if (_stateData.Inventory.Add(SlotType.LeftHand, _stateData.Player.LookAt.ItemType))
                {
                    _stateData.Player.LookAt.Transform.gameObject.SetActive(false);
                    _stateData.Player.LookAt = null;
                }
            }

            if (_stateData.Input.RightHandPressed)
            {
                if (_stateData.Inventory.Add(SlotType.RightHand, _stateData.Player.LookAt.ItemType))
                {
                    _stateData.Player.LookAt.Transform.gameObject.SetActive(false);
                    _stateData.Player.LookAt = null;
                }
            }
        }
    }
}
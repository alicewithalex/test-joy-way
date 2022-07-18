using alicewithalex.Data;
using NoName.Injection;
using NoName.Systems;
using UnityEngine;

namespace alicewithalex.Systems
{
    public class PlayerDropSystem : IStateUpdateSystem
    {
        [Inject] private readonly GameStateData _data;

        public void StateUpdate()
        {
            if (_data.Inventory is null) return;

            if (_data.Input.LeftHandPressed) Throw(_data.Inventory.Remove(HandType.Left));
            if (_data.Input.RightHandPressed) Throw(_data.Inventory.Remove(HandType.Right));
        }

        private void Throw(Pickup pickup)
        {
            if (pickup == null) return;

            pickup.transform.forward = Vector3.ProjectOnPlane(_data.Player.transform.forward, Vector3.up);
            pickup.transform.position = _data.Player.transform.position + pickup.transform.forward;

            pickup.Release();
        }

    }
}
using alicewithalex.Data;
using NoName.Injection;
using NoName.Systems;
using UnityEngine;

namespace alicewithalex.Systems
{
    public class PlayerInteractionSystem : IInitializeSystem, IStateUpdateSystem
    {
        [Inject] private readonly GameStateData _data;

        public void OnInitialize()
        {
            _data.Inventory = new Inventory(_data.Hands);
        }

        public void StateUpdate()
        {
            if (_data.Player is null || !_data.Player.TargetItem) return;

            if (_data.Input.LeftHandPressed) Pickup(HandType.Left, _data.Player.TargetItem);

            if (_data.Input.RightHandPressed) Pickup(HandType.Right, _data.Player.TargetItem);
        }

        private void Pickup(HandType handType, Transform target)
        {
            if (_data.Inventory.IsHolding(handType) || !_data.Pickups.TryGetValue(target, out var pickup)) return;

            _data.Inventory.Add(handType, pickup);

            pickup.Interact();
        }
    }
}
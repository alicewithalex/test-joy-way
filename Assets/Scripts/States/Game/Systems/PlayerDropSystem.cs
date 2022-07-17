using alicewithalex.Data;
using NoName.Injection;
using NoName.Systems;

namespace alicewithalex.Systems
{
    public class PlayerDropSystem : IStateUpdateSystem
    {
        [Inject] private readonly GameStateData _stateData;

        public void StateUpdate()
        {
            if (_stateData.Inventory is null) return;


            if (_stateData.Input.LeftHandReleased)
            {
                var pickable = _stateData.Inventory.Remove(SlotType.LeftHand);

                if (pickable != null)
                {
                    pickable.Transform.position = _stateData.Player.Transform.position + _stateData.Player.Transform.forward;
                    pickable.Show();
                }
            }

            if (_stateData.Input.RightHandReleased)
            {
                var pickable = _stateData.Inventory.Remove(SlotType.RightHand);

                if (pickable != null)
                {
                    pickable.Transform.position = _stateData.Player.Transform.position + _stateData.Player.Transform.forward;
                    pickable.Show();
                }
            }
        }

    }
}
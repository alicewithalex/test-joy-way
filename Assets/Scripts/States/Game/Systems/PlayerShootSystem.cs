using alicewithalex.Data;
using NoName.Injection;
using NoName.Systems;

namespace alicewithalex.Systems
{
    public class PlayerShootSystem : IStateUpdateSystem
    {
        [Inject] private readonly GameStateData _data;

        public void StateUpdate()
        {
            if (_data.Player is null) return;

            if (_data.Input.LeftHandShoot)
                _data.Inventory.UseItem(HandType.Left);

            if (_data.Input.RightHandShoot)
                _data.Inventory.UseItem(HandType.Right);
        }
    }

}
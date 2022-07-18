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

            _data.Inventory.UseItem(HandType.Left, _data.InputConfig.LeftHandShoot);
            _data.Inventory.UseItem(HandType.Right, _data.InputConfig.RightHandShoot);
        }
    }

}
using alicewithalex.Data;
using NoName.Injection;
using NoName.Systems;

namespace alicewithalex.Systems
{
    public class PlayerMotionSystem : IStateUpdateSystem
    {
        [Inject] private readonly GameStateData _data;

        public void StateUpdate()
        {
            if (_data.Player is null) return;

            var player = _data.Player;

            player.Rotate();
            player.Move();

            player.Gravity();

            if (_data.Input.JumpPressed)
                player.Jump();


            player.Execute();
        }
    }
}
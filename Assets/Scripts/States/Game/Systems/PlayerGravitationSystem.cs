using alicewithalex.Data;
using NoName.Injection;
using NoName.Systems;
using UnityEngine;

namespace alicewithalex.Systems
{
    public class PlayerGravitationSystem : IStateUpdateSystem
    {
        [Inject] private readonly GameStateData _gameStateData;

        public void StateUpdate()
        {
            if (_gameStateData.Player is null) return;

            _gameStateData.Player.AddGravity(Time.deltaTime);

            if (_gameStateData.Input.JumpPressed)
            {
                _gameStateData.Player.Jump();
            }
        }
    }
}
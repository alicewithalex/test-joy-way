using alicewithalex.Data;
using NoName.Injection;
using NoName.Systems;
using UnityEngine;

namespace alicewithalex.Systems
{
    public class PlayerGravitationSystem : IStateUpdateSystem
    {
        [Inject] private readonly GameStateData _stateData;

        public void StateUpdate()
        {
            if (_stateData.Player is null) return;

            _stateData.Player.VerticalVelocity-= Time.deltaTime* _stateData.MovementConfig.Gravity;

            if (_stateData.Input.JumpPressed)
            {
                if (!_stateData.Player.CharacterController.isGrounded) return;
                _stateData.Player.VerticalVelocity = Mathf.Sqrt(
                    2 * _stateData.MovementConfig.Gravity * _stateData.MovementConfig.JumpForce);
            }
        }
    }
}
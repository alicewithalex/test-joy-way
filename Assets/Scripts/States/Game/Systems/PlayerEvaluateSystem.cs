using alicewithalex.Data;
using NoName.Injection;
using NoName.Systems;
using UnityEngine;

namespace alicewithalex.Systems
{
    public class PlayerEvaluateSystem : IStateUpdateSystem
    {
        [Inject] private readonly GameStateData _stateData;

        public void StateUpdate()
        {
            if (_stateData.Player is null) return;

            _stateData.Player.CharacterController.Move((_stateData.Player.Velocity + 
                Vector3.up * _stateData.Player.VerticalVelocity) * Time.deltaTime);

            _stateData.Player.Velocity = Vector3.zero;

            if (_stateData.Player.CharacterController.isGrounded)
                _stateData.Player.VerticalVelocity = 0f;
        }
    }
}
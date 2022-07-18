using alicewithalex.Data;
using NoName.Injection;
using NoName.Systems;
using UnityEngine;

namespace alicewithalex.Systems
{
    public class PlayerMovementSystem : IStateUpdateSystem
    {
        [Inject] private readonly GameStateData _stateData;

        public void StateUpdate()
        {
            if (_stateData.Player is null) return;

            var direction = _stateData.Input.Movement.normalized;

            _stateData.Player.CurrentSpeed = Mathf.Lerp(_stateData.Player.CurrentSpeed,
                direction.magnitude * _stateData.MovementConfig.MovementSpeed,
               _stateData.MovementConfig.MovementSmoothness * Time.deltaTime);

            _stateData.Player.Velocity = _stateData.Player.Transform.TransformDirection(
                new Vector3(direction.x, 0f, direction.y)) * _stateData.Player.CurrentSpeed;
        }
    }
}
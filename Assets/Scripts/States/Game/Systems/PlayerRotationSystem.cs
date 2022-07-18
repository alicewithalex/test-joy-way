using alicewithalex.Data;
using NoName.Injection;
using NoName.Systems;
using UnityEngine;

namespace alicewithalex.Systems
{
    public class PlayerRotationSystem : IStateUpdateSystem
    {
        [Inject] private readonly GameStateData _stateData;

        public void StateUpdate()
        {
            if (_stateData.Player is null) return;

            var player = _stateData.Player;

            player.xRot -= _stateData.Input.Look.x * _stateData.MouseConfig.MouseSensitivity;
            player.yRot += _stateData.Input.Look.y * _stateData.MouseConfig.MouseSensitivity;

            player.xRot = Mathf.Clamp(player.xRot, _stateData.MouseConfig.MinPitch, _stateData.MouseConfig.MaxPitch);

            player.Transform.localEulerAngles = new Vector3(0f, player.yRot, 0f);
        }
    }
}
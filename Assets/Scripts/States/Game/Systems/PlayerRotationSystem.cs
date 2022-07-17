using alicewithalex.Data;
using NoName.Injection;
using NoName.Systems;

namespace alicewithalex.Systems
{
    public class PlayerRotationSystem : IStateUpdateSystem
    {
        [Inject] private readonly GameStateData _stateData;

        public void StateUpdate()
        {
            if (_stateData.Player is null) return;

            _stateData.Player.AddRotation(_stateData.Input.Look, _stateData.MouseConfig.MouseSensitivity,
                _stateData.MouseConfig.MinPitch, _stateData.MouseConfig.MaxPitch);
        }
    }
}
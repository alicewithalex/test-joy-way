using alicewithalex.Configs;
using alicewithalex.Data;
using NoName.Providers;
using UnityEngine;

namespace alicewithalex
{
    public class GameStateDataProvider : StateDataProvider<GameStateData>
    {
        [Header("Configs")]
        [SerializeField] private InputConfig _inputConfig;
        [SerializeField] private MouseConfig _mouseConfig;
        [SerializeField] private MotionConfig _movementConfig;
        [SerializeField] private InteractionConfig _pickupConfig;

        protected override void Process(GameStateData stateData, IContainer container)
        {
            stateData.InputConfig = _inputConfig;
            stateData.MouseConfig = _mouseConfig;
            stateData.MovementConfig = _movementConfig;
            stateData.InteractionConfig = _pickupConfig;
        }
    }
}
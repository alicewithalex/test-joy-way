using alicewithalex.Configs;
using alicewithalex.Data;
using NoName.Data;
using NoName.Injection;
using NoName.StateMachine;
using UnityEngine;

namespace alicewithalex.Providers
{
    public class GameStateDataProvider : StateDataProvider
    {

        [SerializeField] private InputConfig _inputConfig;
        [SerializeField] private MouseConfig _mouseConfig;
        [SerializeField] private PickupConfig _pickupConfig;

        public override State State => State.Game;

        public override StateData GetData(IContainer container)
        {

            var data = new GameStateData();

            data.Input = new GameInput(_inputConfig);
            data.InputConfig = _inputConfig;
            data.MouseConfig = _mouseConfig;
            data.PickupConfig = _pickupConfig;

            return data;
        }
    }
}
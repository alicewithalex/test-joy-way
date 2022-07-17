using alicewithalex.Configs;
using alicewithalex.Data;
using NoName.Data;
using NoName.StateMachine;
using UnityEngine;

namespace alicewithalex.Providers
{
    public class GameStateDataProvider : StateDataProvider
    {
        [SerializeField] private InputConfig _inputConfig;
        [SerializeField] private MouseConfig _mouseConfig;

        public override State State => State.Game;

        public override StateData GetData()
        {
            var data = new GameStateData();

            data.Input = new GameInput(_inputConfig);
            data.MouseConfig = _mouseConfig;

            return data;
        }
    }
}
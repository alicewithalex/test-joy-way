using alicewithalex.Data;
using NoName.Data;
using NoName.StateMachine;

namespace alicewithalex.Providers
{
    public class GameStateDataProvider : StateDataProvider
    {
        public override State State => State.Game;

        public override StateData GetData()
        {
            return new GameStateData();
        }
    }
}
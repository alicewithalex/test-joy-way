using alicewithalex.Data;
using NoName.Data;
using NoName.StateMachine;

namespace alicewithalex.Providers
{
    public class StartStateDataProvider : StateDataProvider
    {
        public override State State => State.Start;

        public override StateData GetData()
        {
            return new StartStateData();
        }
    }
}
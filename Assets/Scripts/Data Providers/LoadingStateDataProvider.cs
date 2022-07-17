using alicewithalex.Data;
using NoName.Data;
using NoName.StateMachine;
using UnityEngine;

namespace alicewithalex.Providers
{
    public class LoadingStateDataProvider : StateDataProvider
    {
        public override State State => State.Loading;

        public override StateData GetData()
        {
            return new LoadingStateData();
        }
    }
}
using alicewithalex.Configs;
using alicewithalex.Data;
using NoName.StateMachine;
using UnityEngine;

namespace alicewithalex.Views
{
    public class PlayerView : ViewComponent<GameStateData>
    {
        public override State State => throw new System.NotImplementedException();

        protected override void Process(GameStateData stateData)
        {
            throw new System.NotImplementedException();
        }
    }
}
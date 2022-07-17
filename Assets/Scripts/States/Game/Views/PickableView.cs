using alicewithalex.Data;
using NoName.StateMachine;
using UnityEngine;

namespace alicewithalex.Views
{
    public class PickableView : ViewComponent<GameStateData>
    {
        public override State State => State.Game;

        protected override void Process(GameStateData stateData)
        {
            
        }
    }
}
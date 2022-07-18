using alicewithalex.Data;
using NoName.StateMachine;

namespace alicewithalex.Views
{
    public class WeaponView : ViewComponent<GameStateData>
    {
        public override State State => State.Game;

        protected override void Process(GameStateData stateData)
        {
        }
    }
}
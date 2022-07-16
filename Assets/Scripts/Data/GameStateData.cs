using NoName.StateMachine;

namespace alicewithalex.Data
{
    public class GameStateData : StateData
    {
        public override State State => State.Game;

        public Player Player;
    }
}
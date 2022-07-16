using alicewithalex.UI;
using NoName.StateMachine;

namespace alicewithalex.Systems
{
    public class StartStateUISystem : StateSystemWithScreen<StartStateData, StartUIScreen>
    {
        public override State State => State.Start;

        public override void StateEnter()
        {
            base.StateEnter();
        }

        public override void StateExit()
        {
            base.StateExit();
        }
    }
}
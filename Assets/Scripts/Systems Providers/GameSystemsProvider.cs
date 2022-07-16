using NoName.StateMachine;
using System.Collections.Generic;

namespace alicewithalex.Providers
{
    public class GameSystemsProvider : StateSystemsProvider
    {
        public override IList<IStateSystem> GetStateSystems(IContainer container)
        {
            List<IStateSystem> stateSystems = new List<IStateSystem>();

            stateSystems.Add(new Systems.PlayerRotationSystem());
            stateSystems.Add(new Systems.PlayerGravitationSystem());
            stateSystems.Add(new Systems.PlayerMovementSystem());
            stateSystems.Add(new Systems.PlayerLocomotionEvaluateSystem());

            return stateSystems;
        }
    }
}
using NoName.StateMachine;
using NoName.Systems;

namespace alicewithalex.Providers
{
    public class GameSystemsProvider : StateSystemsProvider
    {
        public override State State => State.Game;

        public override StateSystems GetStateSystems(IContainer container)
        {
            var systems = new StateSystems();

            systems

                .Add(new Systems.PlayerRotationSystem())
                .Add(new Systems.PlayerGravitationSystem())
                .Add(new Systems.PlayerMovementSystem())
                .Add(new Systems.PlayerEvaluateSystem())

                ;

            return systems;
        }
    }
}
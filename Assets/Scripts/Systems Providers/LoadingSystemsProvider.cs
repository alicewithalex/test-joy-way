using NoName.StateMachine;
using NoName.Systems;

namespace alicewithalex.Providers
{
    public class LoadingSystemsProvider : StateSystemsProvider
    {
        public override State State => State.Loading;

        public override StateSystems GetStateSystems(IContainer container)
        {
            var systems = new StateSystems();

            return systems;
        }
    }
}
using NoName.Injection;
using NoName.StateMachine;
using NoName.Systems;
using NoName.UI;

namespace alicewithalex.Providers
{
    public class StartSystemsProvider : StateSystemsProvider
    {
        internal class Dependencies
        {
            [Inject] public UIHub UIHub;
        }

        public override State State => State.Start;

        public override StateSystems GetStateSystems(IContainer container)
        {
            var dependencies = new Dependencies();
            container.Inject(dependencies);

            var systems = new StateSystems();

            systems

                .Add(new Systems.StartMenuSystem(dependencies.UIHub))

                ;

            return systems;
        }
    }
}
using NoName.Providers;
using NoName.Systems;
using alicewithalex.Data;
using NoName.UI;
using NoName.Injection;

namespace alicewithalex.Providers
{
    public class StartSystemsProvider : StateSystemsProvider<StartStateData>
    {
        internal class Depenendecies
        {
            [Inject] public UIHub UIHub;
        }

        protected override void Process(StateSystems systems, IContainer container)
        {
            var dependencies = new Depenendecies();
            container.Inject(dependencies);

            systems

                .Add(new Systems.StartMenuSystem(dependencies.UIHub))

                ;
        }
    }
}

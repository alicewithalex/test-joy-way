using alicewithalex.Systems;
using NoName.StateMachine;
using NoName.Systems;
using System.Collections.Generic;

namespace alicewithalex.Providers
{
    public class GameSystemsProvider : StateSystemsProvider
    {
        public override State State => State.Game;

        public override StateSystems GetStateSystems(IContainer container)
        {
            var systems = new StateSystems();


            return systems;
        }
    }
}
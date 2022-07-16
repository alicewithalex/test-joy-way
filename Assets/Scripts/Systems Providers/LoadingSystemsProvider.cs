using NoName.StateMachine;
using System.Collections.Generic;

namespace alicewithalex.Providers
{
    public class LoadingSystemsProvider : StateSystemsProvider
    {
        public override IList<IStateSystem> GetStateSystems(IContainer container)
        {
            List<IStateSystem> stateSystems = new List<IStateSystem>();

            stateSystems.Add(new Systems.LoadingSystem());

            return stateSystems;
        }
    }
}
using NoName.StateMachine;
using System.Collections.Generic;

public class ExampleStartStateSystemsProvider : StateSystemsProvider
{
    public override IList<IStateSystem> GetStateSystems(IContainer container)
    {
        List<IStateSystem> stateSystems = new List<IStateSystem>();

        stateSystems.Add(new ExamplePlayerMoveSystem());

        return stateSystems;
    }
}

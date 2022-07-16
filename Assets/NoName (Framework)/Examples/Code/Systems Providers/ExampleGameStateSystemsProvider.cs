using NoName.StateMachine;
using System.Collections.Generic;

public class ExampleGameStateSystemsProvider : StateSystemsProvider
{
    public override IList<IStateSystem> GetStateSystems(IContainer container)
    {
        List<IStateSystem> stateSystems = new List<IStateSystem>();

        stateSystems.Add(new ExampleChangeStateSystemToStartOnKeyPressed());

        return stateSystems;
    }
}

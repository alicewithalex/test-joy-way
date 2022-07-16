using NoName.StateMachine;

public interface IStateSystemProvider
{
    System.Collections.Generic.IList<IStateSystem> GetStateSystems(IContainer container);
}

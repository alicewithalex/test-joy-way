using NoName.Systems;

public interface IStateSystemProvider
{
    StateSystems GetStateSystems(IContainer container);
}

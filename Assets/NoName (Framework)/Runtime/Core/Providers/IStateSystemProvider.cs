
namespace NoName.Interfaces
{
    public interface IStateSystemProvider
    {
        Systems.StateSystems GetStateSystems(IContainer container);
    }
}
using NoName.Data;

namespace NoName.Enums
{
    public interface IStateDataProvider
    {
        StateData GetData(IContainer container);
    }
}
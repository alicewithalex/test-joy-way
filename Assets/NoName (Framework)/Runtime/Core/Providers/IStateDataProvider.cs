using NoName.Data;

namespace NoName.StateMachine
{
    public interface IStateDataProvider
    {
        StateData GetData();
    }
}
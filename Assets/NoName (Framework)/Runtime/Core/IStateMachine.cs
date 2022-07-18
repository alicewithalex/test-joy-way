namespace NoName.Enums
{
    public interface IStateMachine
    {
        void ChangeState(State nextState);
    }
}
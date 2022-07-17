namespace NoName.StateMachine
{
    public interface IStateMachine
    {
        void ChangeState(State nextState);
    }
}
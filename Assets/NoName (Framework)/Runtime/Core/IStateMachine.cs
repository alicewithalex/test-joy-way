namespace NoName.StateMachine
{
    public interface IStateMachine
    {
        void ChangeState(State nextState, float delay = 0);
    }
}
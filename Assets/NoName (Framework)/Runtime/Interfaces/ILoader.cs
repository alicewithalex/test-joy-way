namespace NoName.StateMachine
{
    public interface ILoader
    {
        void Load(State state, bool fadeIn = true, bool fadeOut = true);
    }
}
namespace NoName.Enums
{
    public interface ILoader
    {
        void Load(int slot = 0, State state = State.Game);
    }
}
namespace NoName.StateMachine
{
    public interface IStateSystem
    {
        int InheritanceDeep { get; }

        State State { get; }

        public void Initialize();
        public void StateEnter();

        public void StateFixedUpdate();
        public void StateUpdate();

        public void StateLateUpdate();
        public void StateExit();
        public void Destroy();
    }
}
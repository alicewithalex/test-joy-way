using NoName.Injection;
using NoName.UI;

namespace NoName.StateMachine
{

    [System.Serializable]
    public abstract class StateSystemWithScreen<T, U> : StateSystem<T> where T : StateData where U : UIScreen
    {
        public override int InheritanceDeep => base.InheritanceDeep + 1;

        [Inject]
        private readonly UIHub _uiHub;

        private U _screen;

        public U Screen
        {
            get
            {
                if (Screen1 is null)
                    Screen1 = UiHub.GetScreen<U>(State);

                return Screen1;
            }
        }

        public UIHub UiHub => _uiHub;

        public U Screen1 { get => _screen; set => _screen = value; }
    }
}
using NoName.Injection;
using NoName.UI;

namespace NoName.StateMachine
{

    [System.Serializable]
    public abstract class StateSystemWithScreen<Data, UI> : StateSystem<Data> where Data : StateData where UI : UIScreen
    {
        public override int InheritanceDeep => base.InheritanceDeep + 1;

        [Inject]
        private readonly UIHub _uiHub;

        private UI _screen;

        public UI Screen
        {
            get
            {
                if (Screen1 is null)
                    Screen1 = UiHub.GetScreen<UI>(State);

                return Screen1;
            }
        }

        public UIHub UiHub => _uiHub;

        public UI Screen1 { get => _screen; set => _screen = value; }
    }
}
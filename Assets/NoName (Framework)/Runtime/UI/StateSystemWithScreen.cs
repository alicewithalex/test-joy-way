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
                if (_screen is null)
                    _screen = UiHub.GetScreen<UI>(State);

                return _screen;
            }
        }

        public UIHub UiHub => _uiHub;
    }
}
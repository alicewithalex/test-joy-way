using NoName.Injection;
using NoName.Enums;
using NoName.UI;

namespace NoName.Systems
{
    public abstract class UISystem<T> where T : UIScreen
    {
        private readonly UIHub _uiHub;

        private T _screen;

        public abstract State State { get; }

        protected UISystem(UIHub uiHub)
        {
            _uiHub = uiHub;
        }

        protected T Screen
        {
            get
            {
                if (_screen is null)
                {
                    _screen = _uiHub.GetScreen<T>(State);
                }

                return _screen;
            }
        }
    }
}
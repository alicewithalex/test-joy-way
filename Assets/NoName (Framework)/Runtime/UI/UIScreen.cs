using NoName.StateMachine;
using UnityEngine;

namespace NoName.UI
{
    public abstract class UIScreen : MonoBehaviour
    {
        [Header("Core")]
        [SerializeField] private State _state;
        [SerializeField] private CanvasGroup _view;

        public State State => _state;

        public void Show()
        {
            Toggle(true);
        }

        public void Hide()
        {
            Toggle(false);
        }

        private void Toggle(bool on)
        {
            Toggle(_view, on);
        }

        protected void Toggle(CanvasGroup group,bool on)
        {
            group.alpha = on ? 1 : 0;
            group.interactable = on;
            group.blocksRaycasts = on;
        }


    }
}
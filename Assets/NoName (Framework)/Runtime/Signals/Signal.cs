using System;

namespace NoName.Signals
{
    public class Signal : AbstractSignal
    {
        private Action _callback;

        public void AddListener(Action callback)
        {
#if UNITY_EDITOR
            UnityEngine.Debug.Assert(callback.Method.GetCustomAttributes(typeof(
                System.Runtime.CompilerServices.CompilerGeneratedAttribute), inherit: false).Length == 0,
                "Adding anonymous delegates as Signal callbacks is not supported " +
                "(you wouldn't be able to unregister them later).");
#endif

            _callback += callback;
        }

        public void RemoveListener(Action callback)
        {
            _callback -= callback;
        }

        public void Dispatch()
        {
            _callback?.Invoke();
        }
    }
}
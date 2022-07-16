using System;
using System.Collections.Generic;

namespace NoName.Signals
{
    public class SignalsHub
    {
        private readonly Dictionary<Type, ISignal> _signals;

        public SignalsHub()
        {
            _signals = new Dictionary<Type, ISignal>();
        }

        public T Get<T>() where T : ISignal, new()
        {
            var type = typeof(T);

            if (!_signals.ContainsKey(type))
            {
                return (T)Bind(type);
            }

            return (T)_signals[type];
        }


        private ISignal Bind(Type signalType)
        {
            if (_signals.ContainsKey(signalType))
            {
                UnityEngine.Debug.LogError($"Signal with {signalType} type is already registered!");
                return _signals[signalType];
            }

            var signal = (ISignal)Activator.CreateInstance(signalType);
            _signals.Add(signalType, signal);

            return signal;
        }
    }
}
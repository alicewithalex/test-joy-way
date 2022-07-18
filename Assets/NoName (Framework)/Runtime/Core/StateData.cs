using NoName.Factory;
using NoName.Injection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NoName.Data
{
    public abstract class StateData
    {
        [Inject] private IFactory _factory;

        public IFactory Factory => _factory;

        private readonly Dictionary<Type, HashSet<object>> _trash;

        protected StateData()
        {
            _trash = new Dictionary<Type, HashSet<object>>();
        }

        public void Destroy<T>(T @object)
        {
            var type = typeof(T);

            if (!_trash.ContainsKey(type))
            {
                _trash.Add(type, new HashSet<object>());
            }

            _trash[type].Add(@object);
        }

        public bool Exist<T>(out IEnumerable<T> @objects)
        {
            @objects = null;

            if (_trash.TryGetValue(typeof(T), out var set))
            {
                @objects = set.Select(x => (T)x);

                return true;
            }

            return false;
        }

        public void Clean() => _trash.Clear();
    }
}
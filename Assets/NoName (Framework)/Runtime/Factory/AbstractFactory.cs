using System;
using System.Collections.Generic;
using System.Linq;

namespace NoName.Factory
{
    public abstract class AbstractFactory
    {
        public readonly Type Type;

        protected Dictionary<Enum, object> _factoryMap;

        public AbstractFactory(IEnumerable<AbstractFactoryData> factoryData, Type type)
        {
            Type = type;
            _factoryMap = factoryData.ToDictionary(
                x => x.Key,
                y => y.Value);
        }

        protected object GetObject(Enum key)
        {
            if (_factoryMap.TryGetValue(key, out var value))
            {
                return value;
            }

            throw new KeyNotFoundException();
        }

        public abstract object Create(Enum key);

    }
}
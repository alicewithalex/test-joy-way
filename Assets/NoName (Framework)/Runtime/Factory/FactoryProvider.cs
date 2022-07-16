using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace NoName.Factory
{
    public abstract class FactoryProvider<TFactory, TData> : AbstractFactoryProvider
        where TFactory : AbstractFactory where TData : AbstractFactoryData
    {
        [SerializeField]
        private List<TData> _factoryData =
            new List<TData>();

        protected IEnumerable<AbstractFactoryData> FactoryData
        {
            get
            {
                return _factoryData.Select(x => x as AbstractFactoryData);
            }
        }

        public override AbstractFactory CreateFactory()
        {
            return Factory;
        }

        protected abstract TFactory Factory { get; }
    }
}
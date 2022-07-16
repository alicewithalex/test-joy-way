using System;
using UnityEngine;

namespace NoName.Factory
{
    public abstract class AbstractFactoryData
    {
        public abstract Enum Key { get; }

        public abstract object Value { get; }
    }
}
using UnityEngine;

namespace NoName.Factory
{
    public abstract class AbstractFactoryProvider : ScriptableObject
    {
        public abstract AbstractFactory CreateFactory();
    }
}
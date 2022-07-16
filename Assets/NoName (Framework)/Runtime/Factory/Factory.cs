using NoName.Factory;
using System;
using System.Collections.Generic;

public abstract class Factory<TKey, TValue> : AbstractFactory
    where TKey : Enum where TValue : class
{
    public Factory(IEnumerable<AbstractFactoryData> factoryData) : base(factoryData, typeof(TKey))
    {
    }

    protected TValue Get(TKey key)
    {
        return GetObject(key) as TValue;
    }

    protected TKey ParseKey(Enum key)
    {
        return (TKey)key;
    }

    public abstract TValue Create(TKey key);
}

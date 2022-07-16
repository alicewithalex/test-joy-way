using NoName.Factory;
using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class ExampleShapeFactory : Factory<Shape, GameObject>
{
    public ExampleShapeFactory(IEnumerable<AbstractFactoryData> factoryData) : base(factoryData)
    {
    }

    public override object Create(Enum key)
    {
        return Object.Instantiate(Get(ParseKey(key)), null);
    }

    public override GameObject Create(Shape key)
    {
        return Object.Instantiate(Get(ParseKey(key)), null);
    }
}

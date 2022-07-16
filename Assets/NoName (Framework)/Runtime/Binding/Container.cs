using NoName.Injection;
using System;
using System.Collections.Generic;

public class Container : IContainer
{
    public readonly Dictionary<Type, object> _containerMap;

    public Container()
    {
        _containerMap = new Dictionary<Type, object>();
    }

    public void Bind(object source, Type type)
    {
        if (_containerMap.ContainsKey(type)) return;

        _containerMap.Add(type, source);
    }

    public void Bind<T>(T source)
    {
        Bind(source, typeof(T));
    }

    public void Inject(object target)
    {
        Inject(target, target.GetType());
    }

    public void Inject<T>(T target)
    {
        Inject(target, typeof(T));
    }

    private void Inject(object target,Type type)
    {
        var fieldInfos = Reflector.Reflect(type);

        if (fieldInfos == null) return;

        foreach (var fieldInfo in fieldInfos)
        {
            if(_containerMap.TryGetValue(fieldInfo.FieldType,out var value))
            {
                fieldInfo.SetValue(target, value);
            }
        }
    }
}

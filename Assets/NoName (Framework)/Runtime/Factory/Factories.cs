using NoName.Debugging;
using NoName.Factory;
using System;
using System.Collections.Generic;

public static class Factories
{
    const string RESOURCE_PATH = "Factories";

    private static readonly Dictionary<Type, AbstractFactory> _factories =
        new Dictionary<Type, AbstractFactory>();

    [UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.AfterSceneLoad)]
    public static void Setup()
    {
        AbstractFactoryProvider [] abstractFactoryProviders =
            UnityEngine.Resources.LoadAll<AbstractFactoryProvider>(RESOURCE_PATH);

        if(abstractFactoryProviders is null)
        {
#if UNITY_EDITOR
            UnityEngine.Debug.LogWarning($"Resource folder doesn't contains any factory!".Colorize(DColor.Magenta));
#endif
            return;
        }

        foreach (var factoryProvider in abstractFactoryProviders)
        {
            var factory = factoryProvider.CreateFactory();
            var type = factory.GetType();
            if (_factories.ContainsKey(type))
            {

#if UNITY_EDITOR
                UnityEngine.Debug.LogError($"{type.Colorize(DColor.Red,true)} is already in dictionary!" +
                    $" It will be skipped!");
#endif
                continue;
            }

            _factories.Add(type, factory);
        }
    }

    public static T Get<T>() where T : AbstractFactory
    {
        var type = typeof(T);
        if (!_factories.ContainsKey(type)) return null;

        return (T)_factories[type];
    }
}

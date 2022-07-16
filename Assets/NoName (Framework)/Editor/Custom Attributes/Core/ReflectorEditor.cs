using NoName.EditorExtended;
using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ReflectorEditor : MonoBehaviour
{
    private static Type  _buttonType = typeof(ButtonAttribute);
    private static readonly Dictionary<Type, MethodInfo[]> _cachedMethodsInfo = 
        new Dictionary<Type, MethodInfo[]>();
    private static readonly List<MethodInfo> _reusableList = new List<MethodInfo>(64);

    public static MethodInfo[] Reflect(Type type)
    {
        if (_cachedMethodsInfo.ContainsKey(type)) return _cachedMethodsInfo[type];

        var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Static |
            BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.DeclaredOnly);

        if (methods.Length == 0) return null;

        var method = default(MethodInfo);
        for (int methodIndex = 0; methodIndex < methods.Length; methodIndex++)
        {
            method = methods[methodIndex];

            if (method.IsDefined(_buttonType, false))
            {
                _reusableList.Add(method);
            }
        }

        _cachedMethodsInfo[type] = _reusableList.ToArray();
        _reusableList.Clear();

        return _cachedMethodsInfo[type];
    }
}

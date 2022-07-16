using System;
using System.Reflection;
using UnityEngine;

public static class SaveExtensions
{
    
    public static string Save<T>(this T @object) where T : class
    {
        var type = typeof(T);

        if (!type.IsDefined(typeof(SerializableAttribute), false))
        {
            throw new CustomAttributeFormatException("Class don't have Serializeable attribute!");
        }

        return JsonUtility.ToJson(@object, true);
    }

    public static T Load<T>(this string input) where T : class
    {
        var type = typeof(T);

        if (!type.IsDefined(typeof(SerializableAttribute), false))
        {
            throw new CustomAttributeFormatException("Class don't have Serializeable attribute!");
        }

        return JsonUtility.FromJson<T>(input);
    }
}

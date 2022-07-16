using System;

namespace NoName.Injection
{
    public static class Injector
    {
        public static void Inject(this object target, object source)
        {
            var fieldInfos = Reflector.Reflect(target.GetType());

            if (fieldInfos is null) return;

            var type = source.GetType();

            for (int i = 0; i < fieldInfos.Length; i++)
                if (fieldInfos[i].FieldType == type)
                    fieldInfos[i].SetValue(target, source);
        }

        public static void InjectArray<T>(this System.Collections.Generic.IList<T> target, object source)
        {
            for (int i = 0; i < target.Count; i++)
            {
                var fieldInfos = Reflector.Reflect(target[i].GetType());

                if (fieldInfos is null) continue;

                var type = source.GetType();

                for (int j = 0; j < fieldInfos.Length; j++)
                    if (fieldInfos[j].FieldType == type)
                        fieldInfos[j].SetValue(target[i], source);
            }
        }

        /// <summary>
        /// Use this only for inherited abstract classes where need to inject private fields
        /// </summary>
        /// <param name="target"></param>
        /// <param name="source"></param>
        public static void InjectRecursievly(this object target, object source, int recursion = 0)
        {
            var desiredType = target.GetType();
            do
            {
                var fieldInfos = Reflector.Reflect(desiredType);
                var type = source.GetType();

                if (fieldInfos != null)
                {
                    for (int i = 0; i < fieldInfos.Length; i++)
                        if (fieldInfos[i].FieldType == type)
                            fieldInfos[i].SetValue(target, source);
                }

                desiredType = desiredType.BaseType;
                recursion--;
            }
            while (recursion >= 0);
        }

        /// <summary>
        /// Use this only for inherited abstract classes where need to inject private fields
        /// </summary>
        /// <param name="target"></param>
        /// <param name="source"></param>
        public static void InjectRecursievly(this object target, object source,
            Type sourceType, int recursion = 0)
        {
            var desiredType = target.GetType();
            do
            {
                var fieldInfos = Reflector.Reflect(desiredType);
                var type = sourceType;

                if (fieldInfos != null)
                {
                    for (int i = 0; i < fieldInfos.Length; i++)
                        if (fieldInfos[i].FieldType == type)
                            fieldInfos[i].SetValue(target, source);
                }

                desiredType = desiredType.BaseType;
                recursion--;
            }
            while (recursion >= 0);
        }
    }
}
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

        public static void Inject(this object target, object source, Type type)
        {
            var fieldInfos = Reflector.Reflect(target.GetType());

            if (fieldInfos is null) return;

            for (int i = 0; i < fieldInfos.Length; i++)
                if (fieldInfos[i].FieldType == type)
                    fieldInfos[i].SetValue(target, source);
        }


        /// <summary>
        /// Use this only for inherited abstract classes where need to inject private fields
        /// </summary>
        /// <param name="target"></param>
        /// <param name="source"></param>
        public static void Inject(this object target, object source, int recursion = 0)
        {
            if (recursion < 0)
                recursion = 0;

            var desiredType = target.GetType();
            var type = source.GetType();

            do
            {
                var fieldInfos = Reflector.Reflect(desiredType);

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
        public static void Inject(this object target, object source, Type type, int recursion = 0)
        {
            if (recursion < 0)
                recursion = 0;

            var desiredType = target.GetType();

            do
            {
                var fieldInfos = Reflector.Reflect(desiredType);

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
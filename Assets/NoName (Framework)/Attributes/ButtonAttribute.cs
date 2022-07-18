using System;

namespace NoName.EditorExtended
{
    [AttributeUsage(AttributeTargets.Method,AllowMultiple = false, Inherited = true)]
    public class ButtonAttribute : Attribute
    {
        public readonly string Label;

        public ButtonAttribute(string label)
        {
            Label = label;
        }
    }
}
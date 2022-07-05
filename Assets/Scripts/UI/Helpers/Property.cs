using System;

namespace UI.Helpers
{
    public class Property<T> where T : IComparable
    {
        private T _property;
        public Action OnChanged;

        public T Value
        {
            get => _property;
            set
            {
                if (_property.CompareTo(value) != 0)
                {
                    _property = value;
                    OnChanged?.Invoke();
                }
            }
        }
    }
}
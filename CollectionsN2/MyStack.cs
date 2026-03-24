using System;
using System.Collections;

namespace CollectionsN2
{
    public class MyStack : MyCollection
    {
        public void Push(object value)
        {
            ControlSize();
            _items[_count++] = value;
        }

        public object Pop()
        {
            if (_count == 0)
                throw new InvalidOperationException("Stack is empty");

            object value = _items[_count - 1];
            _items[_count - 1] = null;
            _count--;
            return value;
        }

        public object Peek()
        {
            if (_count == 0)
                throw new InvalidOperationException("Stack is empty");

            return _items[_count - 1];
        }

        public void Clear()
        {
            _items = new object[4];
            _count = 0;
        }

        public override void CopyTo(Array array, int index)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));

            for (int i = 0; i < _count; i++)
            {
                array.SetValue(_items[_count - 1 - i], index + i);
            }
        }
    }
}

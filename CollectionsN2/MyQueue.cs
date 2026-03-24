using System;
using System.Collections;

namespace CollectionsN2
{
    public class MyQueue : MyCollection
    {
        public void Enqueue(object value)
        {
            ControlSize();
            _items[_count++] = value;
        }

        public object Dequeue()
        {
            if (_count == 0)
                throw new InvalidOperationException("Queue is empty");

            object value = _items[0];

            for (int i = 0; i < _count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }

            _items[_count - 1] = null;
            _count--;
            return value;
        }

        public object Peek()
        {
            if (_count == 0)
                throw new InvalidOperationException("Queue is empty");
            return _items[0];
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
                array.SetValue(_items[i], index + i);
            }
        }
    }
}

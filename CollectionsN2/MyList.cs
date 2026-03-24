using System;
using System.Collections;

namespace CollectionsN2
{
    public class MyList : MyCollection, IList
    {
        public bool IsFixedSize => false;
        public bool IsReadOnly => false;

        public object this[int index]
        {
            get
            {
                if (index < 0 || index >= _count)
                    throw new IndexOutOfRangeException("Index is out of range");
                return _items[index];
            }
            set
            {
                if (index < 0 || index >= _count)
                    throw new IndexOutOfRangeException("Index is out of range");
                _items[index] = value;
            }
        }

        public int Add(object value)
        {
            ControlSize();
            _items[_count] = value;
            int currentIndex = _count;
            _count++;
            return currentIndex;
        }

        public void Insert(int index, object value)
        {
            if (index < 0 || index > _count)
                throw new IndexOutOfRangeException("Index is out of range");

            ControlSize();
            for (int i = _count; i > index; i--) _items[i] = _items[i - 1];
            _items[index] = value;
            _count++;
        }

        public void Remove(object value)
        {
            int index = IndexOf(value);
            if (index >= 0) RemoveAt(index);
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException("Index is out of range");

            for (int i = index; i < _count - 1; i++) _items[i] = _items[i + 1];
            _items[_count - 1] = null;
            _count--;
        }

        public void Clear()
        {
            _items = new object[4];
            _count = 0;
        }

        public bool Contains(object value) => IndexOf(value) != -1;

        public int IndexOf(object value)
        {
             for (int i = 0; i < _count; i++)
            {
                if (_items[i] == null && value == null) return i;
                if (_items[i] != null && _items[i].Equals(value)) return i;
            }
            return -1;
        }
    }
}


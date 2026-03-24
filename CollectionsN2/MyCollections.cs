using System;
using System.Collections;

namespace CollectionsN2
{
    public abstract class MyCollection : ICollection
    {
        protected object[] _items = new object[4];
        protected int _count = 0;

        public int Count => _count;
        public bool IsSynchronized => false;
        public object SyncRoot => this;

        protected void ControlSize()
        {
            if (_count == _items.Length)
            {
                Array.Resize(ref _items, _items.Length * 2);
            }
        }

        public IEnumerator GetEnumerator() => new MyCollectionEnumerator(_items, _count);

        public virtual void CopyTo(Array array, int index)
        {
            if (array == null) 
                throw new ArgumentNullException(nameof(array));

            for (int i = 0; i < _count; i++)
            {
                array.SetValue(_items[i], index + i);
            }
        }

        public class MyCollectionEnumerator : IEnumerator
        {
            private readonly object[] _items;
            private readonly int _count;
            private int _index;

            public MyCollectionEnumerator(object[] items, int count)
            {
                _items = items ?? throw new ArgumentNullException(nameof(items));
                _count = count;
                Reset();
            }

            public object Current
            {
                get
                {
                    if (_index < 0 || _index >= _count)
                        throw new InvalidOperationException("Enumerator is out of range");
                    return _items[_index];
                }
            }

            public bool MoveNext() => ++_index < _count;
            public void Reset() => _index = -1;
        }
    }
}


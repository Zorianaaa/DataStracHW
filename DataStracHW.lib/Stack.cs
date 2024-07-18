using DataStracHW.lib.Generic;
using DataStracHW.lib.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStracHW.lib
{
    public class Stack<T> : IStack<T>
    {
        private T[] _items;
        private int _count;

        public Stack(int capacity = 4)
        {
            _items = new T[capacity];
            _count = 0;
        }

        public int Count
        {
            get { return _count; }
        }

        public void Push(T item)
        {
            EnsureCapacity(_count + 1);
            _items[_count] = item;
            _count++;
        }

        private void EnsureCapacity(int capacity)
        {
            if (_items.Length < capacity)
            {
                int newCapacity = _items.Length == 0 ? 4 : _items.Length * 2;
                T[] newItems = new T[newCapacity];
                for (int i = 0; i < _count; i++)
                {
                    newItems[i] = _items[i];
                }
                _items = newItems;
            }
        }

        public T Peek()
        {
            if (_count == 0)
            {
                throw new InvalidOperationException("Стек порожній.");
            }
            return _items[_count - 1];
        }

        public T Pop()
        {
            if (_count == 0)
            {
                throw new InvalidOperationException("Стек порожній.");
            }

            T item = _items[_count - 1];
            _items[_count - 1] = default(T);
            _count--;
            return item;
        }

        public T[] ToArray()
        {
            T[] newArray = new T[_count];
            for (int i = 0; i < _count; i++)
            {
                newArray[i] = _items[i];
            }
            return newArray;
        }

        public void Clear()
        {
            for (int i = 0; i < _items.Length; i++)
            {
                _items[i] = default(T);
            }
            _count = 0;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_items[i].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

    }
}

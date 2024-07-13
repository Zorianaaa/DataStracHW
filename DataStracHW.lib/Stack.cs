using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStracHW.lib
{
    public class Stack
    {
        private object[] _items;
        private int _count;

        public Stack(int capacity = 4)
        {
            _items = new object[capacity];
            _count = 0;
        }

        public int Count
        {
            get { return _count; }
        }

        public void Push(object item)
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
                object[] newItems = new object[newCapacity];
                for (int i = 0; i < _count; i++)
                {
                    newItems[i] = _items[i];
                }
                _items = newItems;
            }
        }
        public object Peek()
        {
            if (_count == 0)
            {
                Console.WriteLine("Стек порожній.");
                return null;
            }
            return _items[_count - 1];
        }
        public object[] ToArray()
        {
            object[] newArray = new object[_count];
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
                _items[i] = null;
            }
            _count = 0;
        }

        public bool Contains(object item)
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

using DataStracHW.lib.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStracHW.lib
{
    public class Queue : IQueue
    {
        private object[] _items;
        private int _head;
        private int _tail;
        private int _count;

        public Queue(int capacity = 4)
        {
            _items = new object[capacity];
            _head = 0;
            _tail = 0;
            _count = 0;
        }

        public void Enqueue(object item)
        {
            EnsureCapacity(_count + 1);
            _items[_tail] = item;
            _tail = (_tail + 1) % _items.Length;
            _count++;
        }

        public object Dequeue()
        {
            if (_count == 0)
            {
                Console.WriteLine("Черга порожня.");
                return null;
            }

            object item = _items[_head];
            _items[_head] = null;
            _head = (_head + 1) % _items.Length;
            _count--;
            return item;
        }

        public int Count
        {
            get { return _count; }
        }

        public void Clear()
        {
            for (int i = 0; i < _items.Length; i++)
            {
                _items[i] = null;
            }
            _head = 0;
            _tail = 0;
            _count = 0;
        }

        public bool Contains(object item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_items[(_head + i) % _items.Length].Equals(item))
                {
                    return true;
                }
            }
            return false;
        }

        public object Peek()
        {
            if (_count == 0)
            {
                Console.WriteLine("Черга порожня.");
                return null;
            }
            return _items[_head];
        }

        public object[] ToArray()
        {
            object[] newArray = new object[_count];
            for (int i = 0; i < _count; i++)
            {
                newArray[i] = _items[(_head + i) % _items.Length];
            }
            return newArray;
        }

        private void EnsureCapacity(int capacity)
        {
            if (_items.Length < capacity)
            {
                int newCapacity = _items.Length == 0 ? 4 : _items.Length * 2;
                object[] newItems = new object[newCapacity];
                for (int i = 0; i < _count; i++)
                {
                    newItems[i] = _items[(_head + i) % _items.Length];
                }
                _items = newItems;
                _head = 0;
                _tail = _count;
            }
        }
    }
}

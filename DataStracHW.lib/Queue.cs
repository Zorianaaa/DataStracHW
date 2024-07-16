using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStracHW.lib
{
    public class Queue
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

        public void Enqueue(object item)
        {
            if (_count == _items.Length)
            {
                int newLength = _items.Length * 2;
                object[] newArray = new object[newLength];
                for (int i = 0; i < _count; i++)
                {
                    newArray[i] = _items[(_head + i) % _items.Length];
                }
                _items = newArray;
                _head = 0;
                _tail = _count;
            }
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

    }
}


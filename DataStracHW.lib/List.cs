using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStracHW.lib
{
    public class List : IList
    {
        private object[] _items;
        private int _count;

        public List(int capacity = 4)
        {
            _items = new object[capacity];
            _count = 0;
        }

        public int Count
        {
            get { return _count; }
        }

        public object this[int index]
        {
            get
            {
                if (index < 0 || index >= _count)
                {
                    Console.WriteLine("Неправильний індекс доступу до елемента.");
                    return null;
                }
                return _items[index];
            }
            set
            {
                if (index < 0 || index >= _count)
                {
                    Console.WriteLine("Неправильний індекс доступу до елемента.");
                    return;
                }
                _items[index] = value;
            }
        }

        public void Add(object item)
        {
            EnsureCapacity(_count + 1);
            _items[_count] = item;
            _count++;
        }

        public void Insert(int index, object item)
        {
            if (index < 0 || index > _count)
            {
                Console.WriteLine("Неправильний індекс для вставки елемента.");
                return;
            }

            EnsureCapacity(_count + 1);
            for (int i = _count; i > index; i--)
            {
                _items[i] = _items[i - 1];
            }

            _items[index] = item;
            _count++;
        }

        public void Remove(object item)
        {
            int index = -1;
            for (int i = 0; i < _count; i++)
            {
                if (_items[i].Equals(item))
                {
                    index = i;
                    break;
                }
            }
            if (index != -1)
            {
                RemoveAt(index);
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
            {
                Console.WriteLine("Неправильний індекс для видалення елемента.");
                return;
            }

            for (int i = index; i < _count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }

            _items[_count - 1] = null;
            _count--;
        }

        public void Clear()
        {
            Array.Clear(_items, 0, _count);
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

        public int IndexOf(object item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_items[i].Equals(item))
                {
                    return i;
                }
            }
            return -1;
        }

        public object[] ToArray()
        {
            object[] newArray = new object[_count];
            Array.Copy(_items, newArray, _count);
            return newArray;
        }

        public void Reverse()
        {
            for (int i = 0; i < _count / 2; i++)
            {
                object temp = _items[i];
                _items[i] = _items[_count - i - 1];
                _items[_count - i - 1] = temp;
            }
        }

        private void EnsureCapacity(int capacity)
        {
            if (_items.Length < capacity)
            {
                int newCapacity = _items.Length;
                if (_items.Length == 0)
                {
                    newCapacity = 4;
                }
                else if (_items.Length != 0)
                {
                    newCapacity = _items.Length * 2;
                }
                object[] newItems = new object[newCapacity];
                Array.Copy(_items, newItems, _count);
                _items = newItems;
            }
        }
    }
}

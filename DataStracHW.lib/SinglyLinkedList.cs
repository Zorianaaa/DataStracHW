using DataStracHW.lib.Generic;
using DataStracHW.lib.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStracHW.lib
{
    public class SinglyLinkedListNode<T>
    {
        public object Data { get;}
        public SinglyLinkedListNode Next { get; set; }

        public SinglyLinkedListNode(T data)
        {
            Data = data;
            Next = null;
        }
    }

    public class SinglyLinkedList<T> : ISinglyLinkedList<T>
    {
        public SinglyLinkedListNode<T> First { get; private set; }
        public SinglyLinkedListNode<T> Last { get; private set; }
        public int Count { get; private set; }

        public void Add(T data)
        {
            var newNode = new SinglyLinkedListNode<T>(data);
            if (First == null)
            {
                First = Last = newNode;
            }
            else
            {
                Last.Next = newNode;
                Last = newNode;
            }
            Count++;
        }

        public void Clear()
        {
            First = Last = null;
            Count = 0;
        }

        public bool Contains(T data)
        {
            var current = First;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];
            var current = First;
            for (int i = 0; i < Count; i++)
            {
                array[i] = current.Data;
                current = current.Next;
            }
            return array;
        }
    }
}

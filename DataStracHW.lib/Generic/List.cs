using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStracHW.lib.Generic
{
    public interface IList<T>
    {
        T this[int index] { get; set; }
        void Add(T item);
        void Insert(int index, T item);
        void Remove(T item);
        void RemoveAt(int index);
        int IndexOf(T item);
        int Count { get; }
        void Clear();
        bool Contains(T item);
        T[] ToArray();
        void Reverse();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStracHW.lib.Generic
{
    public interface ISinglyLinkedList<T>
    {
        void Add(T data);
        int Count { get; }
        void Clear();
        bool Contains(T data);
        T[] ToArray();
    }
}

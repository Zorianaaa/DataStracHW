using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStracHW.lib.Generic
{
    public interface IStack<T>
    {
        void Push(T item);
        T Pop();
        T Peek();
        int Count { get; }
        void Clear();
        bool Contains(T item);
        T[] ToArray();
    }
}

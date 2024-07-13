using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStracHW.lib.Interface
{
    public interface IList : ICollection
    {
        object this[int index] { get; set; }
        void Add(object item);
        void Insert(int index, object item);
        void Remove(object item);
        void RemoveAt(int index);
        int IndexOf(object item);
        void Reverse();
    }
}

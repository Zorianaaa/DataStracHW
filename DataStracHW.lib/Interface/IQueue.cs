using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStracHW.lib.Interface
{
    public interface IQueue : ICollection
    {
        void Enqueue(object item);
        object Dequeue();
        object Peek();
    }
}

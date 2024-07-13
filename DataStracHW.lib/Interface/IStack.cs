using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStracHW.lib.Interface
{
    public interface IStack : ICollection
    {
        void Push(object item);
        object Pop();
        object Peek();
    }
}


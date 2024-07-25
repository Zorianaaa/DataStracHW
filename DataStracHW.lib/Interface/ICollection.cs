using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStracHW.lib.Interface
{
    public interface ICollection
    {
        int Count { get; }
        void Clear();
        bool Contains(object item);
        object[] ToArray();
    }
}

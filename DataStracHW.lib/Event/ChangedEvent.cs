using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStracHW.lib.Event
{
    public class DataStructureChangedEventArgs<T> : EventArgs
    {
        public string Action { get; }
        public T Item { get; }

        public DataStructureChangedEventArgs(string action, T item)
        {
            Action = action;
            Item = item;
        }
    }
}

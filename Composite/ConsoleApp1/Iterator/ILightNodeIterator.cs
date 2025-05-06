using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Iterator
{
    public interface ILightNodeIterator
    {
        bool MoveNext();
        LightNode Current { get; }
        void Reset();
    }
}

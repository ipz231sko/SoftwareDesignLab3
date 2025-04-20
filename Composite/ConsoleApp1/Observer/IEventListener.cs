using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Observer
{
    interface IEventListener
    {
        void HandleEvent(string eventType, LightElementNode element);
    }
}

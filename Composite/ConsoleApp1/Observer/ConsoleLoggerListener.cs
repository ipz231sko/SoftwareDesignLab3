using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Observer
{
    class ConsoleLoggerListener : IEventListener
    {
        private readonly string _name;

        public ConsoleLoggerListener(string name)
        {
            _name = name;
        }

        public void HandleEvent(string eventType, LightElementNode element)
        {
            Console.WriteLine($"[{_name}] received '{eventType}' on <{element.TagName}> element.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Flyweight
{
    class HTMLElementFlyweightFactory
    {
        private Dictionary<string, LightElementNode> _flyweights = new Dictionary<string, LightElementNode>();

        public LightElementNode GetElement(string tag)
        {
            if (!_flyweights.ContainsKey(tag))
            {
                _flyweights[tag] = new LightElementNode(tag, DisplayType.Block, TagType.Paired);
            }
            return _flyweights[tag];
        }

        public int Count => _flyweights.Count;
    }
}

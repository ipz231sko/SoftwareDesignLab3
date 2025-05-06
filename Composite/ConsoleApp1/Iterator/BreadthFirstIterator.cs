using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Iterator
{
    public class BreadthFirstIterator : ILightNodeIterator
    {
        private readonly Queue<LightNode> _queue = new Queue<LightNode>();
        private readonly LightNode _root;
        public LightNode Current { get; private set; }
        public BreadthFirstIterator(LightNode root)
        {
            _root = root;
            _queue.Enqueue(root);
        }
        public bool MoveNext()
        {
            if (_queue.Count == 0) return false;
            Current = _queue.Dequeue();
            if (Current is LightElementNode element)
            {
                foreach (var child in element.Children)
                {
                    _queue.Enqueue(child);
                }
            }
            return true;
        }
        public void Reset()
        {
            _queue.Clear();
            _queue.Enqueue(_root);
            Current = null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Iterator
{
    public class DepthFirstIterator : ILightNodeIterator
    {
        private readonly Stack<LightNode> _stack = new Stack<LightNode>();
        private readonly LightNode _root;
        public LightNode Current { get; private set; }

        public DepthFirstIterator(LightNode root)
        {
            _root = root;
            _stack.Push(root);
        }

        public bool MoveNext()
        {
            if (_stack.Count == 0) return false;

            Current = _stack.Pop();

            if (Current is LightElementNode element)
            {
                for(int i = element.Children.Count - 1; i >= 0; i--)
                {
                    _stack.Push(element.Children[i]);
                }
            }
            return true;
        }

        public void Reset()
        {
            _stack.Clear();
            _stack.Push(_root);
            Current = null;
        }
    }
}

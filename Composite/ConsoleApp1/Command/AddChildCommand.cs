using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Command
{
    public class AddChildCommand : ILightCommand
    {
        private readonly LightElementNode _parent;
        private readonly LightNode _child;

        public AddChildCommand(LightElementNode parent, LightNode child)
        {
            _parent = parent;
            _child = child;
        }
        public void Execute()
        {
            _parent.AddChild(_child);
            Console.WriteLine($"[COMMAND] Added child <{(_child as LightElementNode)?.TagName}>");
        }
        public void Undo()
        {
            _parent.RemoveChild(_child);
            Console.WriteLine($"[UNDO] Removed previously added child <{(_child as LightElementNode)?.TagName}>");
        }
    }
}

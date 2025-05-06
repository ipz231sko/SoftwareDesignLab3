using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Command
{
    public class AddClassCommand : ILightCommand
    {
        private readonly LightElementNode _element;
        private readonly string _className;
        public AddClassCommand(LightElementNode element, string className)
        {
            _element = element;
            _className = className;
        }
        public void Execute()
        {
            _element.AddClass(_className);
            Console.WriteLine($"[COMMAND] Added class '{_className}'");
        }
        public void Undo()
        {
            _element.CssClasses.Remove(_className);
            Console.WriteLine($"[UNDO] Removed class '{_className}'");
        }
    }
}

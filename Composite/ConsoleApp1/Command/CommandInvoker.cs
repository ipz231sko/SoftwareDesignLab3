using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Command
{
    public class CommandInvoker
    {
        private readonly Stack<ILightCommand> _history = new Stack<ILightCommand>();

        public void ExecuteCommand(ILightCommand command)
        {
            command.Execute();
            _history.Push(command);
        }

        public void Undo()
        {
            if (_history.Count > 0)
            {
                var command = _history.Pop();
                command.Undo();
            }
            else
            {
                Console.WriteLine("[INFO] Nothing to undo.");
            }
        }

    }
}

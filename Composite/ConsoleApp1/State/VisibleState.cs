using ConsoleApp1.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Command
{
    public class VisibleState : IVisibilityState
    {
        public void OnEnter() => Console.WriteLine("[STATE] Entering Visible state");
        public void OnExit() => Console.WriteLine("[STATE] Existing Visible state");

        public string Render(LightElementNode context)
        {
            return context.OuterHTML;
        }
    }
}

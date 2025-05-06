using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.State
{
    public class CollapsedState : IVisibilityState
    {
        public void OnEnter() => Console.WriteLine("[STATE] Entering Collapsed state");
        public void OnExit() => Console.WriteLine("[STATE] Existing Collapsed state");
        public string Render(LightElementNode context)
        {
            return string.Empty;
        }
    }
}

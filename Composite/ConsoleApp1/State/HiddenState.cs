using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.State
{
    public class HiddenState : IVisibilityState
    {
        public void OnEnter() => Console.WriteLine("[STATE] Entering Hidden state");
        public void OnExit() => Console.WriteLine("[STATE] Existing Hidden state");
        public string Render(LightElementNode context)
        {
            return $"<{context.TagName}> style=\"display:none;\">{context.InnerHTML}</{context.TagName}>";
        }
    }
}

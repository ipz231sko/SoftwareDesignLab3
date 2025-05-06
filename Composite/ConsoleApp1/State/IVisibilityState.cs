using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.State
{
    public interface IVisibilityState
    {
        string Render(LightElementNode context);
        void OnEnter();
        void OnExit();
    }
}

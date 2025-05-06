using ConsoleApp1.Visitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public abstract class LightNode
    {
        public abstract string OuterHTML { get; }
        public abstract string InnerHTML { get; }

        public virtual void OnCreated() { }
        public virtual void OnInserted() { }
        public virtual void OnRemoved() { }
        public virtual void OnStylesApplied() { }
        public virtual void OnClassListApplied() { }
        public virtual void OnTextRendered() { }

        public string RenderWithLifecycle()
        {
            OnCreated();
            OnStylesApplied();
            OnClassListApplied();
            OnInserted();
            string rendered = OuterHTML;
            OnTextRendered();
            return rendered;
        }
        public abstract void Accept(ILightNodeVisitor visitor);
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Visitor
{
    public class NodeCountVisitor : ILightNodeVisitor
    {
        public int ElementCount { get; private set; } = 0;
        public int TextCount { get; private set; } = 0;

        public void VisitElement(LightElementNode element)
        {
            ElementCount++;
        }

        public void VisitText(LightTextNode text)
        {
            TextCount++;
        }
    }
}

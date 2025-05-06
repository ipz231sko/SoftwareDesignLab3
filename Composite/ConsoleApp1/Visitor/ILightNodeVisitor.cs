using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Visitor
{
    public interface ILightNodeVisitor
    {
        void VisitElement(LightElementNode element);
        void VisitText(LightTextNode text);
    }
}

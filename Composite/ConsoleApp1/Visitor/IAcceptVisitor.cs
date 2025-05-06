using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Visitor
{
    public interface IAcceptVisitor
    {
        void Accept(ILightNodeVisitor visitor);
    }
}

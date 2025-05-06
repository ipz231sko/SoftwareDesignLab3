using ConsoleApp1.Flyweight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using ConsoleApp1.Observer;
using ConsoleApp1.Strategy;
using ConsoleApp1.Command;
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)
            System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            var div = new LightElementNode("div", DisplayType.Block, TagType.Paired);
            var p = new LightElementNode("p", DisplayType.Block, TagType.Paired);
            var text = new LightTextNode("Hello from command!");

            var invoker = new CommandInvoker();

            invoker.ExecuteCommand(new AddClassCommand(div, "wrapper"));

            invoker.ExecuteCommand(new AddChildCommand(div, p));
            invoker.ExecuteCommand(new AddChildCommand(p, text));

            invoker.Undo();

        }
    }
}

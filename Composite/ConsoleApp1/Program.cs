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
using ConsoleApp1.State;
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
            div.AddClass("alert");
            div.AddChild(new LightTextNode("Hello in visible state!"));

            Console.WriteLine("Visible");
            Console.WriteLine(div.RenderWithState());

            div.SetVisibilityState(new HiddenState());
            Console.WriteLine("\nHidden");
            Console.WriteLine(div.RenderWithState());

            div.SetVisibilityState(new CollapsedState());
            Console.WriteLine("\nCollapsed");
            Console.WriteLine(div.RenderWithState());
        }
    }
}

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

            //Template Method
            var div = new LightElementNode("div", DisplayType.Block, TagType.Paired);
            div.AddClass("container");

            var paragraph = new LightElementNode("p", DisplayType.Block, TagType.Paired);
            paragraph.AddChild(new LightTextNode("Hello Kateryna!"));

            div.AddChild(paragraph);

            Console.WriteLine("\n=== Render HTML ===");
            Console.WriteLine(div.RenderWithLifecycle());

            Console.WriteLine("\n=== Delete <p> ===");
            div.RemoveChild(paragraph);

            Console.WriteLine("\n=== Render after deletion ===");
            Console.WriteLine(div.RenderWithLifecycle());
        }
    }
}

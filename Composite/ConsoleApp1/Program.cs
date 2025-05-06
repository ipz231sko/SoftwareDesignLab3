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
using ConsoleApp1.Visitor;
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

            var root = new LightElementNode("html", DisplayType.Block, TagType.Paired);
            var body = new LightElementNode("body", DisplayType.Block, TagType.Paired);
            var p1 = new LightElementNode("p", DisplayType.Block, TagType.Paired);
            var p2 = new LightElementNode("p", DisplayType.Block, TagType.Paired);
            var text1 = new LightTextNode("Hello");
            var text2 = new LightTextNode("World");

            p1.AddChild(text1);
            p2.AddChild(text2);
            body.AddChild(p1);
            body.AddChild(p2);
            root.AddChild(body);

            var visitor = new NodeCountVisitor();
            root.Accept(visitor);

            Console.WriteLine($"Element nodes: {visitor.ElementCount}");
            Console.WriteLine($"Text nodes: {visitor.TextCount}");

        }
    }
}

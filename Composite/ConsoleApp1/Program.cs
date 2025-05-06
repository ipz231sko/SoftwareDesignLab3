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

            var root = new LightElementNode("html", DisplayType.Block, TagType.Paired);
            var body = new LightElementNode("body", DisplayType.Block, TagType.Paired);
            var p1 = new LightElementNode("p", DisplayType.Block, TagType.Paired);
            var p2 = new LightElementNode("p", DisplayType.Block, TagType.Paired);
            var text1 = new LightTextNode("Hello");
            var text2 = new LightTextNode("Kateryna");

            p1.AddChild(text1);
            p2.AddChild(text2);
            body.AddChild(p1);
            body.AddChild(p2);
            root.AddChild(body);

            var depthIterator = root.CreateDepthIterator();
            Console.WriteLine("Depth-first traversal (DFS)");
            while (depthIterator.MoveNext())
            {
                var node = depthIterator.Current;
                if (node is LightElementNode el)
                    Console.WriteLine($"Element: <{el.TagName}>");
                else if (node is LightTextNode text)
                    Console.WriteLine($"Text: \"{text.Text}\"");
            }

            var breadthIterator = root.CreateBreadthIterator();
            Console.WriteLine("\nBreadth-first traversal (BFS)");
            while (breadthIterator.MoveNext())
            {
                var node = breadthIterator.Current;
                if (node is LightElementNode el)
                    Console.WriteLine($"Element: <{el.TagName}>");
                else if (node is LightTextNode text)
                    Console.WriteLine($"Text: \"{text.Text}\"");
            }
        }
    }
}

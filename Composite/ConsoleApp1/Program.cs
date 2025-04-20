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

            //Startegy

            IImageLoadingStrategy fileStrategy = new FileImageLoadingStrategy();
            IImageLoadingStrategy networkStrategy = new NetworkImageLoadingStrategy();

            Console.WriteLine("=== 🖼 Картинка з файлу === \n");
            var localImage = new LightImageElement("D:/study/Конструювання програмного забезпечення/Lab3/Composite/ConsoleApp1/images/2.jpg", fileStrategy);
            localImage.Display();

            Console.WriteLine("\nКартинка з Інтернету");
            var webImage = new LightImageElement("https://t3.ftcdn.net/jpg/02/36/99/22/360_F_236992283_sNOxCVQeFLd5pdqaKGh8DRGMZy7P4XKm.jpg", networkStrategy);
            webImage.Display();

            Console.WriteLine("\nЗміна стратегії на льоту (на fileStrategy)");
            webImage.SetStrategy(fileStrategy);
            webImage.Display();

            //Observer
            /*var div = new LightElementNode("div", DisplayType.Block, TagType.Paired);
            div.AddClass("container");
            div.AddChild(new LightTextNode("Hello World"));

            var clickListener = new ConsoleLoggerListener("ClickHandler");
            var hoverListener = new ConsoleLoggerListener("HoverHandler");

            div.AddEventListener("click", clickListener);
            div.AddEventListener("mouseover", hoverListener);

            Console.WriteLine("Initial HTML:");
            Console.WriteLine(div.OuterHTML);

            Console.WriteLine("Triggering 'click' event...");
            div.TriggerEvent("click");

            Console.WriteLine("Triggering 'mouseover' event... \n");
            div.TriggerEvent("mouseover");*/

            /*string filePath = "pg1513.txt";
            await DownloadFileAsync("https://www.gutenberg.org/cache/epub/1513/pg1513.txt", filePath);

            //Composite
            var table = new LightElementNode("table", DisplayType.Block, TagType.Paired);

            var row1 = new LightElementNode("tr", DisplayType.Block, TagType.Paired);
            row1.AddChild(new LightElementNode("td", DisplayType.Inline, TagType.Paired)
                .AddChild(new LightTextNode("Name")));
            row1.AddChild(new LightElementNode("td", DisplayType.Inline, TagType.Paired)
                .AddChild(new LightTextNode("Age")));

            var row2 = new LightElementNode("tr", DisplayType.Block, TagType.Paired);
            row2.AddChild(new LightElementNode("td", DisplayType.Inline, TagType.Paired)
                .AddChild(new LightTextNode("Kateryna")));
            row2.AddChild(new LightElementNode("td", DisplayType.Inline, TagType.Paired)
                .AddChild(new LightTextNode("18")));

            table.AddChild(row1);
            table.AddChild(row2);

            var list = new LightElementNode("ul", DisplayType.Block, TagType.Paired);
            list.AddChild(new LightElementNode("li", DisplayType.Block, TagType.Paired)
                .AddChild(new LightTextNode("Item 1")));
            list.AddChild(new LightElementNode("li", DisplayType.Block, TagType.Paired)
                .AddChild(new LightTextNode("Item 2")));
            list.AddChild(new LightElementNode("li", DisplayType.Block, TagType.Paired)
                .AddChild(new LightTextNode("Item 3")));

            Console.WriteLine("TABLE (outerHTML)");
            Console.WriteLine(table.OuterHTML);

            Console.WriteLine("\nTABLE (innerHTML)");
            Console.WriteLine(table.InnerHTML);

            Console.WriteLine("\nLIST (outerHTML)");
            Console.WriteLine(list.OuterHTML);

            Console.WriteLine("\nLIST (innerHTML)");
            Console.WriteLine(list.InnerHTML);

            //Flyweight
            var factory = new HTMLElementFlyweightFactory();
            var lines = File.ReadAllLines("pg1513.txt");

            long before = GetMemoryUsage();
            var html = ConvertTextToHtml(lines, factory);
            long after = GetMemoryUsage();

            Console.WriteLine("HTML structure created!");
            Console.WriteLine($"The number of flyweight elements: {factory.Count}");
            Console.WriteLine($"Used memory: {after - before} байт");
            Console.WriteLine();
            Console.WriteLine("The beginning of the generated HTML:");
            Console.WriteLine(html.OuterHTML.Substring(0, 5000));*/
        }

       /* static async Task DownloadFileAsync(string url, string filePath)
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();

                File.WriteAllText(filePath, content);
            }
        }

        static LightElementNode ConvertTextToHtml(string[] lines, HTMLElementFlyweightFactory factory)
        {
            var root = new LightElementNode("div", DisplayType.Block, TagType.Paired);

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].TrimEnd();

                if (string.IsNullOrWhiteSpace(line)) continue;

                string tag;
                if (i == 0)
                    tag = "h1";
                else if (line.StartsWith(" "))
                    tag = "blockquote";
                else if (line.Length < 20)
                    tag = "h2";
                else
                    tag = "p";

                var element = factory.GetElement(tag);
                var node = new LightElementNode(element.TagName, element.Display, element.TagType);
                node.AddChild(new LightTextNode(line));
                root.AddChild(node);
            }

            return root;
        }

        static long GetMemoryUsage()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

            return GC.GetTotalMemory(true);
        }*/
    }
}

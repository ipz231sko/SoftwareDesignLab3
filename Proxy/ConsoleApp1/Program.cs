using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "test.txt";
            if (!File.Exists(filePath))
            {
                File.WriteAllLines(filePath, new[]
                {
                    "Hello, World!",
                    "This is a test file.",
                    "It contains multiple lines.",
                    "Each line will be read as a character array."
                });
            }

            Console.WriteLine("== SmartTextReader ==");
            ISmartTextReader reader1 = new SmartTextReader();
            char[][] content1 = reader1.ReadText(filePath);
            PrintText(content1);

            Console.WriteLine("\n== SmartTextChecker ==");
            ISmartTextReader reader2 = new SmartTextChecker();
            char[][] content2 = reader2.ReadText(filePath);
            PrintText(content2);

            Console.WriteLine("\n== SmartTextReaderLocker ==");
            ISmartTextReader reader3 = new SmartTextReaderLocker(@"secret.*\.txt");
            reader3.ReadText(filePath);
            reader3.ReadText("secret_info.txt");
        }
        static void PrintText(char[][] content)
        {
            foreach (var row in content)
            {
                Console.WriteLine(new string(row));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class SmartTextChecker : ISmartTextReader
    {
        private SmartTextReader _realReader;

        public SmartTextChecker()
        {
            _realReader = new SmartTextReader();
        }

        public char[][] ReadText(string path)
        {
            Console.WriteLine($"Opening file: {path}");

            char[][] content;
            try
            {
                content = _realReader.ReadText(path);
                Console.WriteLine($"Successfully read file: {path}");
                Console.WriteLine($"Total lines: {content.Length}");

                int totalChars = 0;
                foreach(var line in content)
                {
                    totalChars += line.Length;
                }

                Console.WriteLine($"Total characters: {totalChars}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error opening file: {ex.Message}");
                throw;
            }

            Console.WriteLine("Closing file.");
            return content;
        }
    }
}

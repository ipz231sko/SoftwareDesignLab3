using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Console logger");
            ILogger consoleLogger = new Logger();
            consoleLogger.Log("This is a logging message");
            consoleLogger.Error("This is an error message");
            consoleLogger.Warn("This is a warning message");

            Console.WriteLine("File logger (via adapter)");
            FileWriter writer = new FileWriter("log.txt");
            ILogger fileLogger = new FileLoggerAdapter(writer);
            fileLogger.Log("This is a logging message");
            fileLogger.Error("This is an error message");
            fileLogger.Warn("This is a warning message");

            Console.WriteLine("Logging is complete. Check the log.txt file for verification.");
        }
    }
}

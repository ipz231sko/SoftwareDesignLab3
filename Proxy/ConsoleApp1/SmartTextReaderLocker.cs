using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class SmartTextReaderLocker : ISmartTextReader
    {
        private SmartTextReader _realReader;
        private Regex _deniedRegex;

        public SmartTextReaderLocker(string pattern)
        {
            _realReader = new SmartTextReader();
            _deniedRegex = new Regex(pattern, RegexOptions.IgnoreCase);
        }

        public char[][] ReadText(string path)
        {
            if(_deniedRegex.IsMatch(path))
            {
                Console.WriteLine("Access denied!");
                return null;
            }
            return _realReader.ReadText(path);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ConsoleApp1.Strategy
{
    internal class FileImageLoadingStrategy : IImageLoadingStrategy
    {
        public void LoadImage(string href)
        {
            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), href);

            if (File.Exists(fullPath))
            {
                Console.WriteLine($"[FILE] Loading image from file system: {fullPath}");
            }
            else
            {
                Console.WriteLine($"[FILE] ❌ Файл не знайдено: {fullPath}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Strategy
{
    public class NetworkImageLoadingStrategy : IImageLoadingStrategy
    {
        public void LoadImage(string href)
        {
            try
            {
                Console.WriteLine($"[NET] 🌍 Trying to load image from: {href}");

                var request = WebRequest.Create(href);
                using (var response = request.GetResponse())
                using (var stream = response.GetResponseStream())
                using (var memoryStream = new MemoryStream())
                {
                    stream.CopyTo(memoryStream);
                    byte[] imageData = memoryStream.ToArray();

                    Console.WriteLine($"[NET] Successfully downloaded image ({imageData.Length} bytes)");

                    Console.Write("[NET] First bytes: ");
                    for (int i = 0; i < Math.Min(10, imageData.Length); i++)
                    {
                        Console.Write($"{imageData[i]:X2}-");
                    }
                    Console.WriteLine("...");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[NET] ❌ Error during download: {ex.Message}");
            }
        }
    }
}

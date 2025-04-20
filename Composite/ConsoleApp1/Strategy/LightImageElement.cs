using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Strategy
{
    class LightImageElement : LightNode
    {
        public string Src { get; }
        private IImageLoadingStrategy _loadingStrategy;

        public LightImageElement(string src, IImageLoadingStrategy strategy)
        {
            Src = src;
            _loadingStrategy = strategy;
        }

        public void SetStrategy(IImageLoadingStrategy strategy)
        {
            _loadingStrategy = strategy;
        }

        public void Display()
        {
            _loadingStrategy.LoadImage(Src);
        }

        public override string OuterHTML => $"<img src=\"{Src}\" />";
        public override string InnerHTML => string.Empty;
    }
}

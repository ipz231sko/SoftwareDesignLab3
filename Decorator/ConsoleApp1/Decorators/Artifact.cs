using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Decorators
{
    public class Artifact : HeroDecorator
    {
        public Artifact(IHero hero) : base(hero) { }

        public override string GetDescription()
        {
            return _hero.GetDescription() + " with Artifact";
        }
        public override int GetPower()
        {
            return _hero.GetPower() + 3;
        }
    }
}

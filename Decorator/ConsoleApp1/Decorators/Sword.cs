using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Decorators
{
    public class Sword : HeroDecorator
    {
        public Sword(IHero hero) : base(hero) { }

        public override string GetDescription()
        {
            return _hero.GetDescription() + " with Sword";
        }
        public override int GetPower()
        {
            return _hero.GetPower() + 9;
        }
    }
}

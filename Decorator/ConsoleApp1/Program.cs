using ConsoleApp1.Decorators;
using ConsoleApp1.Heroes;
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
            IHero hero = new Palladin();
            Console.WriteLine($"{hero.GetDescription()}, Power: {hero.GetPower()}");

            hero = new Sword(hero);
            Console.WriteLine($"{hero.GetDescription()}, Power: {hero.GetPower()}");

            hero = new Armor(hero);
            Console.WriteLine($"{hero.GetDescription()}, Power: {hero.GetPower()}");

            hero = new Artifact(hero);
            Console.WriteLine($"{hero.GetDescription()}, Power: {hero.GetPower()}");
        }
    }
}

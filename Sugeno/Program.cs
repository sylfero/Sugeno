using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sugeno
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IFuzzifier> sun = new List<IFuzzifier>();
            sun.Add(new Trapezoid(0, 0, 0.2, 0.4, "małe"));
            sun.Add(new Triangle(0.3, 0.5, 0.7, "średnie"));
            sun.Add(new Trapezoid(0.6, 0.8, 1, 1, "duże"));
            FuzzifierGroup group1 = new FuzzifierGroup(sun, "sun");

            List<IFuzzifier> pollution = new List<IFuzzifier>();
            pollution.Add(new Trapezoid(0, 0, 0.2, 0.3, "małe"));
            pollution.Add(new Triangle(0.2, 0.4, 0.7, "średnie"));
            pollution.Add(new Trapezoid(0.5, 0.7, 1, 1, "duże"));
            FuzzifierGroup group2 = new FuzzifierGroup(pollution, "pollution");

            List<Rule> rules = new List<Rule>();
            rules.Add(new Rule(1, ("sun", "duże"), ("pollution", "małe")));
            rules.Add(new Rule(0.6, ("sun", "duże"), ("pollution", "średnie")));
            rules.Add(new Rule(0.2, ("sun", "duże"), ("pollution", "duże")));
            rules.Add(new Rule(0.8, ("sun", "średnie"), ("pollution", "małe")));
            rules.Add(new Rule(0.5, ("sun", "średnie"), ("pollution", "średnie")));
            rules.Add(new Rule(0.3, ("sun", "średnie"), ("pollution", "duże")));
            rules.Add(new Rule(0.4, ("sun", "małe"), ("pollution", "małe")));
            rules.Add(new Rule(0.7, ("sun", "małe"), ("pollution", "średnie")));
            rules.Add(new Rule(0.1, ("sun", "małe"), ("pollution", "duże")));

            List<Item> items = new List<Item>();
            items.Add(new Item("Warszawa", ("sun", 0.6), ("pollution", 0.3)));
            items.Add(new Item("Kraków", ("sun", 1), ("pollution", 0.1)));
            items.Add(new Item("Gdańsk", ("sun", 0.9), ("pollution", 0.9)));
            items.Add(new Item("Wrocław", ("sun", 0.8), ("pollution", 0.7)));
            items.Add(new Item("Katowice", ("sun", 0.3), ("pollution", 0.1)));
            items.Add(new Item("Poznań", ("sun", 0.7), ("pollution", 0.6)));
            items.Add(new Item("Gliwice", ("sun", 0.3), ("pollution", 0.1)));

            foreach (var item in items)
            {
                Console.WriteLine($"{item.Label} {item.Calculate(rules, group1, group2)}");
            }
            Console.ReadKey();
        }
    }
}

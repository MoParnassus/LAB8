using System;
using System.Collections.Generic;
using System.Text;

namespace P3Lab7
{
    public class Ink
    {
        public string Colour {get;}
        public int InkLeft {get; set;}

        public Ink(string colour, int inkLeft = 130)
        {
            Colour = colour;
            InkLeft = inkLeft;
        }        
        public static List<Ink> StandardInkSet()
        {
            Console.WriteLine("Standard ink set bought (cost: 100&)\n");
            return new List<Ink> {new Ink("Black"), new Ink("Magenta"), new Ink("Cyan"), new Ink("Yellow")};
        }
        public static List<Ink> EconomyInkSet()
        {
            Console.WriteLine("Economy ink cost bougth (cost: 80&)\n");
            return new List<Ink> {new Ink("Black",120), new Ink("Magenta",80), new Ink("Cyan",80), new Ink("Yellow",80)};            
        }        
    }
}

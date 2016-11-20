using System;
using System.Collections.Generic;

namespace CookieBakery
{
    public class BaseCookie : ICookie
    {
        private readonly string _name;
        private readonly string _bakery;
        private readonly int _number;
        private List<string> Bakeries { get; set; } = new List<string>{ "Grandma's", "Peters Cookies", "Delicious dough", "Awesome Cookies", "Johnny's Bakery", "Cookie heaven", "Bake and shake", "Cake addict", "JKEA", "8-Twelve"};
        private readonly Random _random = new Random();
        public BaseCookie(int number = 0, string name = "cookie", string bakery = "")
        {
            _number = number;
            _name = name;
            _bakery = bakery == "" ? RandomBakery() : bakery;
        }
        private string RandomBakery()
        {
            return Bakeries[_random.Next(0, Bakeries.Count)];
        }

        public virtual string GetName()
        {
            return _name;
        }

        public virtual string GetBakery()
        {
            return _bakery;
        }

        public virtual int GetNumber()
        {
            return _number;
        }
    }
}
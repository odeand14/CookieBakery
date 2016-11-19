using System;

namespace CookieBakery
{
    public class BaseCookie : ICookie
    {
        private readonly string _name;
        private readonly string _bakery;
        private readonly int _number;
        private string[] Bakeries { get; set; } = { "Grandma's", "Peters Cookies", "Delicious dough", "Awesome Cookies", "Johnny's Bakery", "Cookie heaven", "Bake and shake", "Cake addict", "JKEA", "8-Twelve"};
        private readonly Random random = new Random();
        public string RandomBakery() {
            return Bakeries[random.Next(0, Bakeries.Length)];
        }

        public BaseCookie(int number = 0, string name = "Cookie", string bakery = "")
        {
            _number = number;
            _name = name;
            _bakery = (bakery.Equals("")) ? RandomBakery() : bakery;
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
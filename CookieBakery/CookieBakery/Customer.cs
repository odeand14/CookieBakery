using System;
using System.Diagnostics;

namespace CookieBakery
{
    public class Customer
    {
        private string _name;
        public int PurchasedCookies { get; private set; }

        public virtual string GetName()
        {
            return _name;
        }

        public Customer(string name)
        {
            _name = name;
            PurchasedCookies = 0;
        }

        public void BuyCookie()
        {
            var attempts = 0;
            var maxAttempts = 40;
            var random = new Random();
            var max = random.Next();
            var time = new Stopwatch();
            time.Start();
            while (attempts < maxAttempts)
            {
                max = random.Next(1000, 1100);
                while (time.ElapsedMilliseconds < max) { }
                if (CookieBakery.SellToCustomer(this)) PurchasedCookies++;
                time.Restart();
                attempts++;
            }
        }
    }
}

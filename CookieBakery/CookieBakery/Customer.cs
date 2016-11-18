using System;
using System.Diagnostics;

namespace CookieBakery
{
    public class Customer
    {
        private string _name;

        public virtual string GetName()
        {
            return _name;
        }

        public Customer(string name)
        {
            _name = name;
        }

        public void buyCookie()
        {
            var attempts = 0;
            var maxAttempts = 40;
            var Random = new Random();
            var max = Random.Next();
            var time = new Stopwatch();
            time.Start();
            while (attempts < maxAttempts)
            {
                max = Random.Next(1000, 1100);
                while (time.ElapsedMilliseconds < max) { }
                CookieBakery.sellToCustomer(this);
                time.Restart();
                attempts++;
            }
        }
    }
}
